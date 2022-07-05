using Microsoft.AspNetCore.Identity;

namespace ECommerce.DataAccess;

public class ECommerceUserIdentity : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime? BirthDate { get; set; }
    public string DocumentNumber { get; set; } = null!;
}