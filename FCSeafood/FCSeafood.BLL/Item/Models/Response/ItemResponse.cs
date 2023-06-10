namespace FCSeafood.BLL.Item.Models.Response;

public record ItemResponse(
    bool IsSuccessful
  , string Message
  , ItemModel? ItemModel
) : IResponse;