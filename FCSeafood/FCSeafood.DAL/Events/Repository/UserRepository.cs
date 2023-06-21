using Microsoft.Extensions.DependencyInjection;

namespace FCSeafood.DAL.Events.Repository;

public class UserRepository : Base.BaseRepository<UserDbo, UserModel> {
    private readonly AddressRepository _addressRepository;
    private readonly UserCredentialRepository _userCredentialRepository;

    public UserRepository(EventFCSeafoodContext context, IServiceProvider provider) : base(context) {
        _addressRepository = provider.GetService<AddressRepository>()!;
        _userCredentialRepository = provider.GetService<UserCredentialRepository>()!;
    }

    protected override IQueryable<UserDbo> NoTracking() =>
        this.Entities
            .Include(x => x.RoleTDbo)
            .Include(x => x.GenderTDbo)
            .Include(x => x.AddressDbo)
            .AsNoTracking();

    protected override void AddExtensionToModel(ref UserModel userModel, UserDbo entity) {
        if (entity.RoleTDbo != null) {
            var (isSuccessful, model) = RoleTRepository.ToModel(entity.RoleTDbo);
            if (isSuccessful)
                userModel.Role = model;
        }

        if (entity.GenderTDbo != null) {
            var (isSuccessful, model) = GenderTRepository.ToModel(entity.GenderTDbo);
            if (isSuccessful)
                userModel.Gender = model;
        }

        if (entity.AddressDbo != null) {
            var (isSuccessful, model) = _addressRepository.ToModel(entity.AddressDbo);
            if (isSuccessful)
                userModel.Address = model;
        }

        if (entity.Id != Guid.Empty) {
            var (isSuccessful, model) = _userCredentialRepository.FindByConditionAsync(x => x.Id == entity.Id).Result;
            if (isSuccessful)
                userModel.Email = model!.Email;
        }
    }
}