using Microsoft.Extensions.DependencyInjection;

namespace FCSeafood.DAL.Events.Repository;

public class OrderRepository : Base.BaseRepository<OrderDbo, OrderModel> {
    private readonly UserRepository _userRepository;
    private readonly OrderEntityRepository _orderEntityRepository;

    public OrderRepository(EventFCSeafoodContext context, IServiceProvider provider) : base(context) {
        _userRepository = provider.GetService<UserRepository>()!;
        _orderEntityRepository = provider.GetService<OrderEntityRepository>()!;
    }

    protected override IQueryable<OrderDbo> NoTracking() =>
        this.Entities
            .Include(x => x.UserDbo)
            .Include(x => x.UserDbo!.RoleTDbo)
            .Include(x => x.UserDbo!.GenderTDbo)
            .Include(x => x.UserDbo!.AddressDbo)
            .AsNoTracking();

    protected override void AddExtensionToModel(ref OrderModel orderModel, OrderDbo entity) {
        if (entity.UserDbo != null) {
            var (isSuccessful, model) = _userRepository.ToModel(entity.UserDbo);
            if (isSuccessful)
                orderModel.User = model;
        }

        if (entity.Id != Guid.Empty) {
            var (isSuccessful, models) = _orderEntityRepository.FindByConditionListAsync(x => x.OrderDboId == entity.Id).Result;
            if (isSuccessful)
                orderModel.Orders = models.ToList();
        }
    }
}