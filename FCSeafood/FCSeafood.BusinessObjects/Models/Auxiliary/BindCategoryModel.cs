using FCSeafood.BusinessObjects.Models.Common;

namespace FCSeafood.BusinessObjects.Models.Auxiliary;

public class BindCategoryModel {
    public CategoryTModel CategoryTModel { get; set; } = new();
    public SubCategoryTModel SubCategoryTModel { get; set; } = new();
}