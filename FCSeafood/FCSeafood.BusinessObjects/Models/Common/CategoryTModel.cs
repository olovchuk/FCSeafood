namespace FCSeafood.BusinessObjects.Models.Common;

public class CategoryTModel {
    public CategoryType Type { get; set; }
    public string Name { get; set; } = "";
    public string ImagePath { get; set; } = "";

    public List<SubcategoryTModel> SubcategoryTModelList { get; set; } = new();
}