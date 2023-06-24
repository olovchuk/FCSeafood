namespace FCSeafood.BLL.Order.Models.Response;

public record OrderListResponse(
    bool IsSuccessful
  , string Message
  , IEnumerable<OrderModel> OrderModels
) : IResponse;