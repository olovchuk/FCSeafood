namespace FCSeafood.BLL.Delivery.Models.Response;

public record DeliveryListResponse(
    bool IsSuccessful
  , string Message
  , IEnumerable<DeliveryModel> DeliveryModels
) : IResponse;