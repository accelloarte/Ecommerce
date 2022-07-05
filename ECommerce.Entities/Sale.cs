using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Entities;

public class Sale
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InvoiceId { get; set; }

    public Customer Customer { get; set; } = null!;

    public int CustomerFk { get; set; }

    public DateTime SaleDate { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public PaymentMethod PaymentMethod { get; set; }

    public decimal TotalSale { get; set; }
}