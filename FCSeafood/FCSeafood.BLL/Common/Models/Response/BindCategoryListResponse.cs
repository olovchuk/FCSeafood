namespace FCSeafood.BLL.Common.Models.Response;

public record BindCategoryListResponse(bool IsSuccessful, string Message, IEnumerable<BindCategoryModel> BindCategoryListModel) : IResponse;