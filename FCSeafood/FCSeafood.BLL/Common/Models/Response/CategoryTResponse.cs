namespace FCSeafood.BLL.Common.Models.Response;

public record CategoryTResponse(bool IsSuccessful, string Message, CategoryTModel? CategoryTModel) : IResponse;