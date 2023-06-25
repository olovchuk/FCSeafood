namespace FCSeafood.BLL.Common.Models.Response;

public record DeliveryStatusTListResponse(
    bool IsSuccessful
  , string Message
  , IEnumerable<DeliveryStatusTModel> DeliveryStatusTListModel
) : IResponse;