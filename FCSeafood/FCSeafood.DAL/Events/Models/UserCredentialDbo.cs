namespace FCSeafood.DAL.Events.Models;

[Table("T_User_Credentials", Schema = "dbo")]
public class UserCredentialDbo {
    [Column("PK_User")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("Email")]
    public string Email { get; set; } = "";

    [Column("Password")]
    public string Password { get; set; } = "";

    [Column("Last_Login_Date")]
    public DateTime? LastLoginDate { get; set; }

    [Column("Last_Password_Changed_Date")]
    public DateTime? LastPasswordChangedDate { get; set; }

    public UserCredentialDbo() { }

    public UserCredentialDbo(UserCredentialModel credentialModel) {
        Id = credentialModel.Id;
        Email = credentialModel.Email;
        Password = credentialModel.Password;
        LastLoginDate = credentialModel.LastLoginDate;
        LastPasswordChangedDate = credentialModel.LastPasswordChangedDate;
    }
}