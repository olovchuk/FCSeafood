using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCSeafood.DAL.Events.Models;

[Table("T_User_Credentials")]
public class UserCredential {
    [Column("PK_User")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("Email")]
    public string Email { get; set; }

    [Column("Password")]
    public string Password { get; set; }

    [Column("Last_Login_Date")]
    public DateTime? LastLoginDate { get; set; }

    [Column("Last_Password_Changed_Date")]
    public DateTime? LastPasswordChangedDate { get; set; }
}