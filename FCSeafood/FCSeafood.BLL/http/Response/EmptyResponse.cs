namespace FCSeafood.BLL.http.Response;

public record EmptyResponse(bool IsSuccessful, string Message) : IResponse;