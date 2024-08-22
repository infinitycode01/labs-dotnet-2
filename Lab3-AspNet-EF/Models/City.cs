using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3_AspNet_EF.Models;

[Table("cities")]
public class City
{
    [Key]
    [Column("city_id")]
    public int Id { get; init; }

    [Required]
    [Column("city_name")]
    public string Name { get; init; }

    [Required]
    [Column("area_code")]
    public string AreaCode { get; init; }
    
    public override string ToString()
    {
        return $"CityId: {Id}, CityName: {Name}, AreaCode: {AreaCode};";
    }
}