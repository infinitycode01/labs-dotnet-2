using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3_AspNet_EF.Models;

[Table("calls")]
public class Call
{
    [Key]
    [Column("call_id")]
    public int CallId { get; init; }
    
    [Required]
    [ForeignKey("Phone")]
    [Column("phone_id")]
    public int PhoneId { get; init; }
    
    [Required]
    [ForeignKey("City")]
    [Column("city_id")]
    public int CityId { get; init; }

    [Required]
    [Column("call_date")]
    public DateOnly Date { get; init; }

    [Required]
    [Column("call_duration")]
    public int Duration { get; init; }
    
    [Required]
    [ForeignKey("Tariff")]
    [Column("tariff_id")]
    public int TariffId { get; init; }
    
    public override string ToString()
    {
        return $"CallId: {CallId}, UserId: {PhoneId}, CityId: {CityId}, Date: {Date}, Duration: {Duration}, TariffId: {TariffId};";
    }
}