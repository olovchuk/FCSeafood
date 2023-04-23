namespace FCSeafood.BLL.Common.Models.Response;

public record GetSubCategoryTypeResponse(bool IsSuccessful, string Message, List<SubCategoryTypeModel> SubCategoryTypeModels);