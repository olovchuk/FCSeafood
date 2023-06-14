namespace FCSeafood.DAL.Events.Repository;

public class DeliveryRepository : Base.BaseRepository<DeliveryDbo, DeliveryModel> {
    public DeliveryRepository(EventFCSeafoodContext context) : base(context) { }
}