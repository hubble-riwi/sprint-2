using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sprint_2.Models;

public class User
{
    [Key]
    [Column("id")]
    public long Id { get; set; }
    
    [Required]
    [Column("first_name")]
    public string? FirstName { get; set; }
    
    [Required]
    [Column("last_name")]
    public string? LastName { get; set; }

    [Required]
    [Column("username")]
    public string? Username { get; set; }

    [Required]
    [Column("email")]
    public string? Email { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("cellphone")]
    public string? CellPhone { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("city")]
    public string? City { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("zipcode")]
    public string? Zipcode { get; set; }

    [Column("country")]
    public string? Country { get; set; }

    [Column("gender")]
    public string? Gender { get; set; } 
    
    [Column("age")]
    public int? Age { get; set; }

    [Column("password")]
    public string? Password { get; set; }
    
}