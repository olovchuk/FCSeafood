namespace FCSeafood.BLL.Item.Models.Response;

public record RatingTResponse(
    bool IsSuccessful
  , string Message
  , RatingType? Type
) : IResponse;