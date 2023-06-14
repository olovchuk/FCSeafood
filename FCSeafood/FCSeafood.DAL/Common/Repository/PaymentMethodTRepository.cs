namespace FCSeafood.DAL.Common.Repository;

public class PaymentMethodTRepository : Base.BaseRepository<PaymentMethodTDbo> {
    public PaymentMethodTRepository(CommonFCSeafoodContext context) : base(context) { }

    public static (bool success, PaymentMethodTModel model) ToModel(PaymentMethodTDbo dbo) {
        if (dbo.Equals(null))
            return (false, new PaymentMethodTModel());

        var model = new Mapper(MapperConfig.ConfigureCommon).Map<PaymentMethodTModel>(dbo);
        return (true, model);
    }
}