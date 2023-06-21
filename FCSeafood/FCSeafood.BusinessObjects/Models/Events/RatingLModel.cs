namespace FCSeafood.BusinessObjects.Models.Events;

public class RatingLModel {
    public Guid Id { get; set; }

    public Guid UserDboId { get; set; }

    public Guid ItemDboId { get; set; }

    public RatingType Rating { get; set; }
}