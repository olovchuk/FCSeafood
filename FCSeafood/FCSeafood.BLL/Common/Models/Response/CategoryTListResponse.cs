namespace FCSeafood.BLL.Common.Models.Response;

public record CategoryTListResponse(bool IsSuccessful, string Message, IEnumerable<CategoryTModel> CategoryTListModel) : IResponse;