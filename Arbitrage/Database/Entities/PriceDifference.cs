using System.ComponentModel.DataAnnotations;

namespace Arbitrage.Database.Entities;

public class PriceDifference
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Symbol1 { get; set; } = string.Empty;
    [Required]
    public string Symbol2 { get; set; } = string.Empty;
    [Required]
    public decimal Difference { get; set; }
}
