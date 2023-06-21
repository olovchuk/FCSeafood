namespace FCSeafood.BLL.Item.Models.Response;

public record ItemListResponse(
    bool IsSuccessful
  , string Message
  , IEnumerable<ItemModel> ItemModels
) : IResponse;