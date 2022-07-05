namespace ECommerce.Dto.Request;

public record ResetPasswordDtoRequest(string Email);

public record ResetPasswordWithTokenRequest(string Token, string Email, string Password);