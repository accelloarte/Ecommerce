using ECommerce.Dto.Request;
using ECommerce.Dto.Response;
using ECommerce.Services;

namespace ECommerceAPI.Apis;

public static class Accounts
{
    public static async Task<IResult> LoginAsync(LoginDtoRequest request, IUserService service)
    {
        var response = await service.LoginAsync(request);

        return response.Success ? Results.Ok(response) : Results.Json(response, statusCode: StatusCodes.Status401Unauthorized);
    }

    public static async Task<IResult> RegisterAsync(RegisterDtoRequest request, IUserService service)
    {
        var response = await service.CreateUserAsync(request);

        return response.Success ? Results.Ok(response) : Results.Json(response, statusCode: StatusCodes.Status400BadRequest);
    }

    public static async Task<IResult>
        SendTokenToResetPasswordAsync(ResetPasswordDtoRequest request,
            IUserService service) => Results.Ok(await service.SendTokenToResetPasswordAsync(request));

    public static void RegisterApis(this WebApplication app)
    {
        app.MapPost("/api/Accounts/Login", LoginAsync)
            .Produces<LoginDtoResponse>()
            .Produces<LoginDtoResponse>(StatusCodes.Status401Unauthorized);

        app.MapPost("/api/Accounts/Register", RegisterAsync)
            .Produces<BaseResponseGeneric<string>>();

        app.MapPost("api/Account/SendTokenToResetPassword", SendTokenToResetPasswordAsync)
            .Produces<BaseResponseGeneric<string>>();
    }
    
}