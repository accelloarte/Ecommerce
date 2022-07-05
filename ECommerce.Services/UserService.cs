using ECommerce.DataAccess;
using ECommerce.Dto.Request;
using ECommerce.Dto.Response;
using ECommerce.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ECommerce.Repositories;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ECommerce.Services;

public class UserService : IUserService
{
    private readonly UserManager<ECommerceUserIdentity> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IOptions<AppSettings> _options;
    private readonly ILogger<UserService> _logger;
    private readonly ICustomerRepository _customerRepository;
    private readonly ISecretService _secretService;

    public UserService(UserManager<ECommerceUserIdentity> userManager, 
        RoleManager<IdentityRole> roleManager, 
        IOptions<AppSettings> options, 
        ILogger<UserService> logger, 
        ICustomerRepository customerRepository, ISecretService secretService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _options = options;
        _logger = logger;
        _customerRepository = customerRepository;
        _secretService = secretService;
    }

    // Create a new user
    public async Task<BaseResponseGeneric<string>> CreateUserAsync(RegisterDtoRequest request)
    {
        var response = new BaseResponseGeneric<string>();

        try
        {
            var user = new ECommerceUserIdentity
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = Convert.ToDateTime(request.BirthDate),
                DocumentNumber = request.DocumentNumber
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                response.Success = true;
                response.ErrorMessage = "No se pudo crear el usuario";
                result.Errors.Select(x => x.Description)
                    .ToList()
                    .ForEach(x => _logger.LogCritical("Error de Validacion {x}", x));
                return response;
            }

            // Get user by email
            var userIdentity = await _userManager.FindByEmailAsync(request.Email);

            if (userIdentity != null)
            {
                if (!await _roleManager.RoleExistsAsync(Constants.AdminRole))
                    await _roleManager.CreateAsync(new IdentityRole(Constants.AdminRole));

                if (!await _roleManager.RoleExistsAsync(Constants.CustomerRole))
                    await _roleManager.CreateAsync(new IdentityRole(Constants.CustomerRole));

                if (await _userManager.Users.CountAsync() == 1)
                {
                    await _userManager.AddToRoleAsync(userIdentity, Constants.AdminRole);
                }
                else
                {
                    await _userManager.AddToRoleAsync(userIdentity, Constants.CustomerRole);
                }

                var customer = new Customer
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    BirthDate = Convert.ToDateTime(request.BirthDate),
                    DocumentNumber = request.DocumentNumber,
                    Email = request.Email,
                };

                await _customerRepository.CreateAsync(customer);

                // send email with sendgrid
                //var sendGridClient = new SendGridClient(Environment.GetEnvironmentVariable("SENDGRID_API_KEY", EnvironmentVariableTarget.User));

                var sendGridClient = new SendGridClient(_secretService.GetSecret("SendGridApiKey"));

                var message = MailHelper.CreateSingleEmail(
                    new EmailAddress("netfs@mitocodenetwork.com", "Curso NET Ecuador"),
                    new EmailAddress(request.Email, request.FirstName + " " + request.LastName),
                    "Bienvenido a Curso NET",
                    "Hola " + request.FirstName + " " + request.LastName + " bienvenido a Curso NET",
                    "<p>Hola " + request.FirstName + " " + request.LastName + " bienvenido a Curso NET</p>");

                await sendGridClient.SendEmailAsync(message);

                response.Success = true;
                response.Result = userIdentity.Id;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            response.Success = false;
            response.ErrorMessage = "User creation failed";
        }

        return response;
    }

    public async Task<LoginDtoResponse> LoginAsync(LoginDtoRequest request)
    {
        var response = new LoginDtoResponse();

        try
        {
            var identity = await _userManager.FindByEmailAsync(request.UserName);

            if (identity == null)
            {
                response.Success = false;
                response.ErrorMessage = "User not found";
                return response;
            }

            var result = await _userManager.CheckPasswordAsync(identity, request.Password);
            if (!result)
            {
                response.Success = false;
                response.ErrorMessage = "Password incorrect";
                return response;
            }

            var expiredDate = DateTime.Now.AddMinutes(_options.Value.Jwt.TokenExpiration);

            response.FullName = $"{identity.FirstName} {identity.LastName}";

            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Sid, identity.Id),
                new Claim(ClaimTypes.Name, response.FullName),
                new Claim(ClaimTypes.Email, identity.Email),
                new Claim(ClaimTypes.NameIdentifier, identity.DocumentNumber),
            };

            var roles = await _userManager.GetRolesAsync(identity);
            foreach (var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.Value.Jwt.SigningKey));

            var signingCredentials = new SigningCredentials(
                symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(signingCredentials);

            var payload = new JwtPayload(
                issuer: _options.Value.Jwt.Issuer,
                audience: _options.Value.Jwt.Audience,
                claims: authClaims,
                notBefore: DateTime.Now,
                expires: expiredDate);

            var token = new JwtSecurityToken(header, payload);

            response.Token = new JwtSecurityTokenHandler().WriteToken(token);
            response.Success = true;
        }
        catch (Exception e)
        {
            response.Success = false;
            response.ErrorMessage = e.Message;
            _logger.LogCritical(e, "{message}", e.Message);
        }

        return response;
    }

    public async Task<BaseResponseGeneric<string>> SendTokenToResetPasswordAsync(ResetPasswordDtoRequest request)
    {
        var response = new BaseResponseGeneric<string>();

        try
        {
            // find user 
            var userIdentity = await _userManager.FindByEmailAsync(request.Email);
            if (userIdentity == null)
            {
                response.Success = false;
                response.ErrorMessage = "User not found";
                return response;
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(userIdentity);

            // send email
            var sendGridClient = new SendGridClient(_secretService.GetSecret("SendGridApiKey"));

            var from = new EmailAddress("netfs@mitocodenetwork.com", "Curso NET Ecuador");
            var to = new EmailAddress(request.Email, userIdentity.FirstName + " " + userIdentity.LastName);

            //var message = MailHelper.CreateSingleTemplateEmail(from, to, "d-d8f94e65a75340ce969b52feefa0983f", token);

            //message.SetTemplateData(new
            //{
            //    name = userIdentity.FirstName + " " + userIdentity.LastName,
            //    token
            //});

            var message = MailHelper.CreateSingleEmail(
                from,
                to,
                "Recuperar contraseña",
                "Recuperar contraseña",
                "<p>Hola " + userIdentity.FirstName + " " + userIdentity.LastName + "</p>" +
                "<p>Para recuperar su contraseña copie el siguiente token:</p>" +
                "<p><strong>" + token + "</strong></p>");

            await sendGridClient.SendEmailAsync(message);

            response.Success = true;
            response.Result = token;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            response.Success = false;
            response.ErrorMessage = "Error al enviar el token";
        }
        
        return response;
    }

    public async Task<BaseResponseGeneric<string>> ResetPasswordAsync(ResetPasswordWithTokenRequest request)
    {
        var response = new BaseResponseGeneric<string>();

        try
        {
            var userIdentity = await _userManager.FindByEmailAsync(request.Email);

            if (userIdentity == null)
            {
                response.Success = false;
                response.ErrorMessage = "User not found";
                return response;
            }

            var identity = await _userManager.ResetPasswordAsync(userIdentity, request.Token, request.Password);

            // send email

            response.Success = identity.Succeeded;
            response.Result = userIdentity.Id;
            response.ErrorMessage = identity.Errors.Select(x => x.Description).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            response.Success = false;
            response.ErrorMessage = "No se pudo resetear el usuario";
        }

        return response;
    }

    public async Task<BaseResponse> ChangePasswordAsync(ChangePasswordDtoRequest request)
    {
        var response = new BaseResponse();

        try
        {
            var userIdentity = await _userManager.FindByEmailAsync(request.Email);

            if (userIdentity == null)
            {
                response.Success = false;
                response.ErrorMessage = "User not found";
                return response;
            }

            var identity = await _userManager.ChangePasswordAsync(userIdentity, request.Password, request.NewPassword);

            response.Success = identity.Succeeded;
            response.ErrorMessage = identity.Errors.Select(x => x.Description).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            response.Success = false;
            response.ErrorMessage = "Error al cambiar la contraseña";
        }
        
        return response;
    }
}