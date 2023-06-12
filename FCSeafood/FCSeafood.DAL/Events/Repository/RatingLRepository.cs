namespace FCSeafood.DAL.Events.Repository;

public class RatingLRepository : Base.BaseRepository<RatingLDbo, RatingLModel> {
    public RatingLRepository(EventFCSeafoodContext context) : base(context) { }
}