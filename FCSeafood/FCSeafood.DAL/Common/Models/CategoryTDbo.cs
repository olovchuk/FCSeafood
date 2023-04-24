namespace FCSeafood.DAL.Common.Models;

[Table("E_Category_Type", Schema = "enum")]
public class CategoryTDbo {
    [Column("PK_Category_Type")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = "";

    [Column("Image_Path")]
    public string ImagePath { get; set; } = "";
}