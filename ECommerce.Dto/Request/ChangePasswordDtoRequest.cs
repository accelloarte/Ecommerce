using System.ComponentModel.DataAnnotations;

namespace ECommerce.Dto.Request;

public record ChangePasswordDtoRequest
{
    [EmailAddress]
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;

    [Compare(nameof(ConfirmPassword))] 
    public string NewPassword { get; init; } = null!;
    public string ConfirmPassword { get; init; } = null!;
}