namespace FCSeafood.BLL.Item.Models.Params;

public record SetItemRatingParams(Guid UserId, Guid ItemId, RatingType RatingType);