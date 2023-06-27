namespace FCSeafood.DAL.Infrastructure;

public static class MapperConfig {
    public static MapperConfiguration ConfigureCommon =>
        new(
            cfg => {
                cfg.CreateMap<CategoryTDbo, CategoryTModel>()
                   .ForMember(
                        memberOptions => memberOptions.Type
                      , options => options.MapFrom(source => Enum.GetName(typeof(CategoryType), source.Id))
                    );
                cfg.CreateMap<CurrencyCodeTDbo, CurrencyCodeTModel>()
                   .ForMember(
                        memberOptions => memberOptions.Type
                      , options => options.MapFrom(source => Enum.GetName(typeof(CurrencyCodeType), source.Id))
                    );
                cfg.CreateMap<DeliveryStatusTDbo, DeliveryStatusTModel>()
                   .ForMember(
                        memberOptions => memberOptions.Type
                      , options => options.MapFrom(source => Enum.GetName(typeof(DeliveryStatusType), source.Id))
                    );
                cfg.CreateMap<GenderTDbo, GenderTModel>()
                   .ForMember(
                        memberOptions => memberOptions.Type
                      , options => options.MapFrom(source => Enum.GetName(typeof(GenderType), source.Id))
                    );
                cfg.CreateMap<ItemStatusTDbo, ItemStatusTModel>()
                   .ForMember(
                        memberOptions => memberOptions.Type
                      , options => options.MapFrom(source => Enum.GetName(typeof(ItemStatusType), source.Id))
                    );
                cfg.CreateMap<PaymentMethodTDbo, PaymentMethodTModel>()
                   .ForMember(
                        memberOptions => memberOptions.Type
                      , options => options.MapFrom(source => Enum.GetName(typeof(PaymentMethodType), source.Id))
                    );
                cfg.CreateMap<RatingTDbo, RatingTModel>()
                   .ForMember(
                        memberOptions => memberOptions.Type
                      , options => options.MapFrom(source => Enum.GetName(typeof(RatingType), source.Id))
                    );
                cfg.CreateMap<RoleTDbo, RoleTModel>()
                   .ForMember(
                        memberOptions => memberOptions.Type
                      , options => options.MapFrom(source => Enum.GetName(typeof(RoleType), source.Id))
                    );
                cfg.CreateMap<SubcategoryTDbo, SubcategoryTModel>()
                   .ForMember(
                        memberOptions => memberOptions.Type
                      , options => options.MapFrom(source => Enum.GetName(typeof(SubcategoryType), source.Id))
                    );
                cfg.CreateMap<TemperatureUnitTDbo, TemperatureUnitTModel>()
                   .ForMember(
                        memberOptions => memberOptions.Type
                      , options => options.MapFrom(source => Enum.GetName(typeof(TemperatureUnitType), source.Id))
                    );
            }
        );

    public static MapperConfiguration ConfigureEvent =>
        new(
            cfg => {
                cfg.CreateMap<AddressDbo, AddressModel>();
                cfg.CreateMap<DeliveryDbo, DeliveryModel>();
                cfg.CreateMap<ItemDbo, ItemModel>();
                cfg.CreateMap<OrderEntityDbo, OrderEntityModel>();
                cfg.CreateMap<OrderDbo, OrderModel>();
                cfg.CreateMap<RatingLDbo, RatingLModel>()
                   .ForMember(
                        memberOptions => memberOptions.Rating
                      , options => options.MapFrom(source => Enum.GetName(typeof(RatingType), source.RatingTDboId))
                    );
                cfg.CreateMap<ResetPasswordLDbo, ResetPasswordLModel>();
                cfg.CreateMap<UserCredentialDbo, UserCredentialModel>();
                cfg.CreateMap<UserDbo, UserModel>();
            }
        );
}