using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopMax.Model;

[Table("Contracts")]
public class Contract
{

    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public short Status { get; set; } = 0;

    public int OfferId { get; set; }

    public Offer Offer { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    public IList<Chat> Chats { get; set; }

}