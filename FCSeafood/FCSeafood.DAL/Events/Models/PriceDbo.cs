namespace FCSeafood.DAL.Events.Models;

[Table("L_Price", Schema = "erfx")]
public class PriceDbo {
    [Column("PK_Price")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("Price")]
    public double Price { get; set; }

    [Column("FK_Currency_Code_Type")]
    public int CurrencyCodeTDboId { get; set; }
    public CurrencyCodeTDbo? CurrencyCodeTDbo { get; set; }
}