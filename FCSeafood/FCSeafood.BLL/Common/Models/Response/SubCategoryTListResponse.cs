namespace FCSeafood.BLL.Common.Models.Response;

public record SubCategoryTListResponse(bool IsSuccessful, string Message, IEnumerable<SubCategoryTypeModel> SubCategoryTypeModels) : IResponse;