namespace FCSeafood.BLL.Common.Models.Response;

public record PaymentMethodTListResponse(
    bool IsSuccessful
  , string Message
  , IEnumerable<PaymentMethodTModel> PaymentMethodTListModel
) : IResponse;