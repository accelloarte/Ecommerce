using ECommerce.Dto.Request;
using ECommerce.Dto.Response;

namespace ECommerce.Services;

public interface IUserService
{
    Task<BaseResponseGeneric<string>> CreateUserAsync(RegisterDtoRequest request);
    Task<LoginDtoResponse> LoginAsync(LoginDtoRequest request);

    Task<BaseResponseGeneric<string>> SendTokenToResetPasswordAsync(ResetPasswordDtoRequest request);

    Task<BaseResponseGeneric<string>> ResetPasswordAsync(ResetPasswordWithTokenRequest request);

    Task<BaseResponse> ChangePasswordAsync(ChangePasswordDtoRequest request);
}