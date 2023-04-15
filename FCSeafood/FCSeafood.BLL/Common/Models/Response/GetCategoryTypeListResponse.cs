namespace FCSeafood.BLL.Common.Models.Response;

public record GetCategoryTypeListResponse(bool IsSuccessful, string Message, List<CategoryTypeModel>? CategoryTypeModels);