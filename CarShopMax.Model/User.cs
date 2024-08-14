using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShopMax.Model;

[Table("Users")]
public class User
{

    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    [MinLength(5)]
    public string Username { get; set; }

    [Required]
    [MaxLength(30)]
    [MinLength(5)]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public string ProfileImage { get; set; }

    public IEnumerable<Offer> Offers { get; set; }

}
