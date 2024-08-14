using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShopMax.Model;

[Table("Offers")]
public class Offer
{

    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public short OfferType { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(5)]
    public string OfferBrand { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(5)]
    public string OfferBrandModel { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(5)]
    public string OfferBrandSubModel { get; set; }

    [Required]
    [MaxLength(500)]
    [MinLength(5)]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string Image { get; set; }

    public IList<Contract> Contracts { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

}
