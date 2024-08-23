using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3_AspNet_EF.Models;

[Table("phones")]
public class Phone
{
    [Key]
    [Column("phone_id")]
    public int Id { get; init; }
    
    [Required]
    [ForeignKey("Subscriber")]
    [Column("subscriber_id")]
    public int SubscriberId { get; init; }
    
    [Required]
    [Column("phone_number")]
    public string PhoneNumber { get; init; }

    public override string ToString()
    {
        return $"PhoneId: {Id}, SubscriberId: {SubscriberId}, PhoneNumber: {PhoneNumber};";
    }
}