namespace FCSeafood.BLL.http.Response;

public record ExistsResponse(bool IsSuccessful, string Message, bool? IsExists) : IResponse;