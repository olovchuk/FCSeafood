namespace FCSeafood.BLL.Delivery.Models.Response;

public record DeliveryResponse(
    bool IsSuccessful
  , string Message
  , DeliveryModel? DeliveryModel
) : IResponse;