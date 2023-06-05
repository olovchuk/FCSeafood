namespace FCSeafood.BLL.Common.Models.Response;

public record SubcategoryTListResponse(
    bool IsSuccessful
  , string Message
  , IEnumerable<SubcategoryTModel> SubcategoryTListModel
) : IResponse;