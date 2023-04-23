namespace FCSeafood.BLL.Common.Models.Response;

public record GetSubCategoryTypeResponse(bool IsSuccessful, string Message, IEnumerable<SubCategoryTypeModel> SubCategoryTypeModels) : IResponse;