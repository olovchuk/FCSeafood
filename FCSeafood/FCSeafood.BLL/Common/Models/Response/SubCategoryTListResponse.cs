namespace FCSeafood.BLL.Common.Models.Response;

public record SubCategoryTListResponse(bool IsSuccessful, string Message, IEnumerable<SubCategoryTModel> SubCategoryTModels) : IResponse;