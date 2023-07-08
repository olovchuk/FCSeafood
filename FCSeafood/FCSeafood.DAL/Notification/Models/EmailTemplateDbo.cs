namespace FCSeafood.DAL.Notification.Models;

[Table("T_Email_Template", Schema = "dbo")]
public class EmailTemplateDbo {
    [Column("PK_Email_Template")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Code")]
    public string Code { get; set; } = "";

    [Column("Subject")]
    public string Subject { get; set; } = "";

    [Column("Body")]
    public string Body { get; set; } = "";
}