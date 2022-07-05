using System.ComponentModel.DataAnnotations;

namespace ECommerce.Dto.Request;

public class CustomerDtoRequest
{
    [Required]
    [StringLength(20, ErrorMessage = "El campo FirstName debe ser de maximo de 20 caracteres")]
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;

    [EmailAddress(ErrorMessage = "El correo no es valido")]
    public string Email { get; set; } = null!;

    public string DocumentNumber { get; set; } = null!;

    [RegularExpression("^(19|20)\\d\\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$", 
        ErrorMessage = "El formato debe ser (YYYY-MM-DD)")]
    public string BirthDate { get; set; } = null!;

    public int? Dependants { get; set; }
}