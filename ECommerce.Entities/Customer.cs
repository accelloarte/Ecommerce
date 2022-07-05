using System.ComponentModel.DataAnnotations;

namespace ECommerce.Entities
{
    public class Customer : EntityBase
    {
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(100)]
        public string LastName { get; set; } = null!;

        [StringLength(200)]
        public string Email { get; set; } = null!;
        
        public DateTime BirthDate { get; set; }

        [StringLength(20)]
        public string DocumentNumber { get; set; } = null!;

        public int? Dependants { get; set; }

        [Timestamp] public byte[] Version { get; set; } 

    }
}