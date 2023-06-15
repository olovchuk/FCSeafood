namespace FCSeafood.BLL.Delivery.Models.Response;

public record TrackingNumberResponse(
    bool IsSuccessful
  , string Message
  , string? TrackingNumber
) : IResponse;