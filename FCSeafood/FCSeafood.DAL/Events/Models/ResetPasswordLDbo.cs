namespace FCSeafood.DAL.Events.Models;

[Table("L_Reset_Password", Schema = "lnk")]
public class ResetPasswordLDbo {
    [Column("PK_Reset_Password")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("FK_User")]
    public Guid UserDboId { get; set; }

    [Column("Code")]
    public int Code { get; set; }

    [Column("Created_Date")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [Column("Expiration_Date")]
    public DateTime ExpirationDate { get; set; } = DateTime.Now;

    public ResetPasswordLDbo() { }

    public ResetPasswordLDbo(ResetPasswordLModel model) {
        Id = model.Id;
        UserDboId = model.UserDboId;
        Code = model.Code;
        CreatedDate = model.CreatedDate;
        ExpirationDate = model.ExpirationDate;
    }
}