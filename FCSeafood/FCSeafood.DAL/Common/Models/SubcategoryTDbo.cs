namespace FCSeafood.DAL.Common.Models;

[Table("E_Subcategory_Type", Schema = "enum")]
public class SubcategoryTDbo {
    [Column("PK_Subcategory_Type")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = "";

    [Column("Image_Path")]
    public string ImagePath { get; set; } = "";

    [Column("FK_Category_Type")]
    public int CategoryTDboId { get; set; }
}