using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3_AspNet_EF.Models;

[Table("subscribers")]
public class Subscriber
{
    [Key]
    [Column("subscriber_id")]
    public int SubscriberId { get; init; }
    
    [Required]
    [Column("first_name")]
    public string FirstName { get; init; }
    
    [Required]
    [Column("last_name")]
    public string LastName { get; init; }
    
    [Column("middle_name")]
    public string MiddleName { get; init; }
    
    [Required]
    [Column("address")]
    public string Address { get; init; }

    public override string ToString()
    {
        return $"SubscriberId: {SubscriberId}, FirstName: {FirstName}, LastName: {LastName}, MiddleName: {MiddleName}, Address: {Address};";
    }
}