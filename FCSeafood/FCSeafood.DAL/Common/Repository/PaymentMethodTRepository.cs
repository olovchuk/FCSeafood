namespace FCSeafood.DAL.Common.Repository;

public class PaymentMethodTRepository : Base.BaseRepository<PaymentMethodTDbo> {
    public PaymentMethodTRepository(CommonFCSeafoodContext context) : base(context) { }

    public static (bool success, PaymentMethodTModel model) ToModel(PaymentMethodTDbo dbo) {
        if (dbo.Equals(null))
            return (false, new PaymentMethodTModel());

        var model = new Mapper(MapperConfig.ConfigureCommon).Map<PaymentMethodTModel>(dbo);
        return (true, model);
    }

    public static (bool success, IReadOnlyCollection<PaymentMethodTModel> models) ToModel(IEnumerable<PaymentMethodTDbo> listDbo) {
        if (listDbo.Equals(null))
            return (false, Array.Empty<PaymentMethodTModel>());

        var listResult = new List<PaymentMethodTModel>();
        foreach (var result in listDbo.Select(ToModel)) {
            if (!result.success)
                return (false, Array.Empty<PaymentMethodTModel>());
            listResult.Add(result.model);
        }

        return (true, listResult);
    }
}