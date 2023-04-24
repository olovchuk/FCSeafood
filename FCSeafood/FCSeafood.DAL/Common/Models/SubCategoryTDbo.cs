namespace FCSeafood.DAL.Common.Models;

[Table("E_Sub_Category_Type", Schema = "enum")]
public class SubCategoryTDbo {
    [Column("PK_Sub_Category_Type")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = "";
}