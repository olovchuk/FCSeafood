namespace FCSeafood.BLL.Common.Models.Response;

public record GenderTListResponse(
    bool IsSuccessful
  , string Message
  , IEnumerable<GenderTModel> GenderTListModel
) : IResponse;