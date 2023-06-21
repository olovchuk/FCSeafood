namespace FCSeafood.DAL.Common.Models;

[Table("E_Payment_Method_Type", Schema = "enum")]
public class PaymentMethodTDbo {
    [Column("PK_Payment_Method_Type")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = "";
}