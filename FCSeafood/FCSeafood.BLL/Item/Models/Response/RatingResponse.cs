namespace FCSeafood.BLL.Item.Models.Response;

public record RatingResponse(
    bool IsSuccessful
  , string Message
  , RatingType? Type
) : IResponse;