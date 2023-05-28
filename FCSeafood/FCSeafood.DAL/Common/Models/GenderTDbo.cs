namespace FCSeafood.DAL.Common.Models;

[Table("E_Gender_Type", Schema = "enum")]
public class GenderTDbo {
    [Column("PK_Gender_Type")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = "";
}