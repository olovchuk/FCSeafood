namespace FCSeafood.BLL.http.Response;

public record CountResponse(bool IsSuccessful, string Message, int? Count) : IResponse;