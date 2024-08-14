using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopMax.Model;

[Table("Chats")]
public class Chat
{

    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Text { get; set; }

    public int ContractId { get; set; }

    public Contract Contract { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

}
