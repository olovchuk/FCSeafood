namespace FCSeafood.BLL.Delivery.Models.Params;

public record InsertDeliveryParams(
    Guid UserId
  , Guid OrderId
  , PaymentMethodType PaymentMethodType
  , string Notes
);