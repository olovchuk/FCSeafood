namespace FCSeafood.DAL.Infrastructure;

public static class MapperConfig {
    public static MapperConfiguration ConfigureCommon => new(cfg => {
        cfg.CreateMap<CategoryTDbo, CategoryTModel>().ForMember(memberOptions => memberOptions.Type, options => options.MapFrom(source => Enum.GetName(typeof(CategoryType), source.Id)));
        cfg.CreateMap<CurrencyCodeTDbo, CurrencyCodeTModel>().ForMember(memberOptions => memberOptions.Type, options => options.MapFrom(source => Enum.GetName(typeof(CurrencyCodeType), source.Id)));
        cfg.CreateMap<GenderTDbo, GenderTModel>().ForMember(memberOptions => memberOptions.Type, options => options.MapFrom(source => Enum.GetName(typeof(GenderType), source.Id)));
        cfg.CreateMap<ItemStatusTDbo, ItemStatusTModel>().ForMember(memberOptions => memberOptions.Type, options => options.MapFrom(source => Enum.GetName(typeof(ItemStatusType), source.Id)));
        cfg.CreateMap<RoleTDbo, RoleTModel>().ForMember(memberOptions => memberOptions.Type, options => options.MapFrom(source => Enum.GetName(typeof(RoleType), source.Id)));
        cfg.CreateMap<SubcategoryTDbo, SubcategoryTModel>().ForMember(memberOptions => memberOptions.Type, options => options.MapFrom(source => Enum.GetName(typeof(SubcategoryType), source.Id)));
        cfg.CreateMap<TemperatureUnitTDbo, TemperatureUnitTModel>().ForMember(memberOptions => memberOptions.Type, options => options.MapFrom(source => Enum.GetName(typeof(TemperatureUnitType), source.Id)));
    });

    public static MapperConfiguration ConfigureEvent => new(cfg => {
        cfg.CreateMap<AddressDbo, AddressModel>();
        cfg.CreateMap<ItemDbo, ItemModel>();
        cfg.CreateMap<PriceDbo, PriceModel>();
        cfg.CreateMap<UserCredentialDbo, UserCredentialModel>();
        cfg.CreateMap<UserDbo, UserModel>();
    });
}