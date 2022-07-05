using ECommerce.Dto.Request;
using ECommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    // Post : api/users
    [HttpPost]
    public async Task<IActionResult> CreateUser(RegisterDtoRequest user)
    {
        return Ok(await _service.CreateUserAsync(user));
    }

    // Post : api/users/login
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDtoRequest user)
    {
        return Ok(await _service.LoginAsync(user));
    }

    // Post: api/users/sendtokentoresetpassword
    [HttpPost("sendtokentoresetpassword")]
    public async Task<IActionResult> SendTokenToResetPassword(ResetPasswordDtoRequest request)
    {
        return Ok(await _service.SendTokenToResetPasswordAsync(request));
    }

    // Post: api/users/resetpassword
    [HttpPost("resetpassword")]
    public async Task<IActionResult> ResetPassword(ResetPasswordWithTokenRequest request)
    {
        return Ok(await _service.ResetPasswordAsync(request));
    }

    // Post: api/users/changepassword
    [HttpPost("changepassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordDtoRequest request)
    {
        return Ok(await _service.ChangePasswordAsync(request));
    }
}