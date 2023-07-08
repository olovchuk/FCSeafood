namespace FCSeafood.DAL.Common.Repository;

public class DeliveryStatusTRepository : Base.BaseRepository<DeliveryStatusTDbo> {
    public DeliveryStatusTRepository(CommonFCSeafoodContext context) : base(context) { }

    public static (bool success, DeliveryStatusTModel model) ToModel(DeliveryStatusTDbo dbo) {
        if (dbo.Equals(null))
            return (false, new DeliveryStatusTModel());

        var model = new Mapper(MapperConfig.ConfigureCommon).Map<DeliveryStatusTModel>(dbo);
        return (true, model);
    }

    public static (bool success, IReadOnlyCollection<DeliveryStatusTModel> models) ToModel(
        IEnumerable<DeliveryStatusTDbo> listDbo
    ) {
        if (listDbo.Equals(null))
            return (false, Array.Empty<DeliveryStatusTModel>());

        var listResult = new List<DeliveryStatusTModel>();
        foreach (var result in listDbo.Select(ToModel)) {
            if (!result.success)
                return (false, Array.Empty<DeliveryStatusTModel>());
            listResult.Add(result.model);
        }

        return (true, listResult);
    }
}