namespace FCSeafood.DAL.Events.Repository;

public class ResetPasswordLRepository : Base.BaseRepository<ResetPasswordLDbo, ResetPasswordLModel> {
    public ResetPasswordLRepository(EventFCSeafoodContext context) : base(context) { }
}