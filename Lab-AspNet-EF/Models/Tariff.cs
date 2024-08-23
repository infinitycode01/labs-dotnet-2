using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3_AspNet_EF.Models;

[Table("tariffs")]
public class Tariff
{
    [Key]
    [Column("tariff_id")]
    public int Id { get; init; }
    
    [Required]
    [ForeignKey("City")]
    [Column("city_id")]
    public int CityId { get; init; }
    
    [Required]
    [Column("rate_per_minute")]
    public decimal RatePerMinute { get; set; }
    
    public override string ToString()
    {
        return $"TariffId: {Id}, CityId: {CityId}, RatePerMinute: {RatePerMinute};";
    }
}