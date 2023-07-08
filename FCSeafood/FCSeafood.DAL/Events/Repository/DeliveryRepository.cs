using Microsoft.Extensions.DependencyInjection;

namespace FCSeafood.DAL.Events.Repository;

public class DeliveryRepository : Base.BaseRepository<DeliveryDbo, DeliveryModel> {
    private readonly UserRepository _userRepository;
    private readonly OrderRepository _orderRepository;

    public DeliveryRepository(EventFCSeafoodContext context, IServiceProvider provider) : base(context) {
        _userRepository = provider.GetService<UserRepository>()!;
        _orderRepository = provider.GetService<OrderRepository>()!;
    }

    protected override IQueryable<DeliveryDbo> NoTracking() =>
        this.Entities
            .Include(x => x.UserDbo)
            .Include(x => x.UserDbo!.RoleTDbo)
            .Include(x => x.UserDbo!.GenderTDbo)
            .Include(x => x.UserDbo!.AddressDbo)
            .Include(x => x.OrderDbo)
            .Include(x => x.OrderDbo!.Orders)
            .Include(x => x.DeliveryStatusTDbo)
            .Include(x => x.PaymentMethodTDbo)
            .AsNoTracking();

    protected override void AddExtensionToModel(ref DeliveryModel deliveryModel, DeliveryDbo entity) {
        if (entity.UserDbo != null) {
            var (isSuccessful, model) = _userRepository.ToModel(entity.UserDbo);
            if (isSuccessful)
                deliveryModel.User = model!;
        }

        if (entity.OrderDbo != null) {
            var (isSuccessful, model) = _orderRepository.ToModel(entity.OrderDbo);
            if (isSuccessful)
                deliveryModel.Order = model!;
        }

        if (entity.OrderDbo != null) {
            var (isSuccessful, model) = _orderRepository.ToModel(entity.OrderDbo);
            if (isSuccessful)
                deliveryModel.Order = model!;
        }

        if (entity.DeliveryStatusTDbo != null) {
            var (isSuccessful, model) = DeliveryStatusTRepository.ToModel(entity.DeliveryStatusTDbo);
            if (isSuccessful)
                deliveryModel.DeliveryStatus = model;
        }

        if (entity.PaymentMethodTDbo != null) {
            var (isSuccessful, model) = PaymentMethodTRepository.ToModel(entity.PaymentMethodTDbo);
            if (isSuccessful)
                deliveryModel.PaymentMethod = model;
        }
    }
}