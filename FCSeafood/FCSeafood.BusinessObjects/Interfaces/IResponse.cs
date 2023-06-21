namespace FCSeafood.BusinessObjects.Interfaces;

public interface IResponse {
    bool IsSuccessful { get; init; }
    string Message { get; init; }
}