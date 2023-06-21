namespace FCSeafood.DAL.Common.Repository;

public class DeliveryStatusTRepository : Base.BaseRepository<DeliveryStatusTDbo> {
    public DeliveryStatusTRepository(CommonFCSeafoodContext context) : base(context) { }

    public static (bool success, DeliveryStatusTModel model) ToModel(DeliveryStatusTDbo dbo) {
        if (dbo.Equals(null))
            return (false, new DeliveryStatusTModel());

        var model = new Mapper(MapperConfig.ConfigureCommon).Map<DeliveryStatusTModel>(dbo);
        return (true, model);
    }
}