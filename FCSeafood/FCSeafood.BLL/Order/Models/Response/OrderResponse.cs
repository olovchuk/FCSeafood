namespace FCSeafood.BLL.Order.Models.Response;

public record OrderResponse(
    bool IsSuccessful
  , string Message
  , OrderModel? Order
) : IResponse;