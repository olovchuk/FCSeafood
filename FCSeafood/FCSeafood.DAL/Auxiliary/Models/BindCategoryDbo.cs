namespace FCSeafood.DAL.Auxiliary.Models;

[Table("B_Category", Schema = "erfx")]
public class BindCategoryDbo {
    [Column("PK_Category")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("FK_Category_Type")]
    public CategoryType CategoryType { get; set; }

    [Column("FK_Subcategory_Type")]
    public SubcategoryType SubcategoryType { get; set; }
}