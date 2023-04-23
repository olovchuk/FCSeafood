namespace FCSeafood.BusinessObjects.Models;

public class BindCategoryModel {
    public CategoryTypeModel CategoryTypeModel { get; set; } = new();
    public SubCategoryTypeModel SubCategoryTypeModel { get; set; } = new();
}