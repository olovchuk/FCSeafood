namespace FCSeafood.DAL.Common.Models;

[Table("E_Currency_Code_Type", Schema = "enum")]
public class CurrencyCodeTDbo {
    [Column("PK_Currency_Code_Type")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = "";
}