using System.ComponentModel.DataAnnotations;

namespace ECommerce.Dto.Request;

public class RegisterDtoRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    [EmailAddress]
    public string Email { get; set; } = null!;
    public string? BirthDate { get; set; }
    public string DocumentNumber { get; set; } = null!;
    
    public string Password { get; set; } = null!;

    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = null!;
}