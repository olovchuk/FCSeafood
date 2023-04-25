using FCSeafood.BusinessObjects.Models.Common;

namespace FCSeafood.BusinessObjects.Models.Auxiliary;

public class BindCategoryModel {
    public CategoryTypeModel CategoryTypeModel { get; set; } = new();
    public SubCategoryTypeModel SubCategoryTypeModel { get; set; } = new();
}