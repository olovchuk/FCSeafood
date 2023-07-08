using FCSeafood.DAL.Common.Repository;

namespace FCSeafood.BLL.Services;

public class CommonService {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(CommonService));

    private readonly CategoryTRepository _categoryTRepository;
    private readonly SubcategoryTRepository _subcategoryTRepository;
    private readonly PaymentMethodTRepository _paymentMethodTRepository;
    private readonly GenderTRepository _genderTRepository;
    private readonly DeliveryStatusTRepository _deliveryStatusTRepository;

    public CommonService(
        CategoryTRepository categoryTRepository
      , SubcategoryTRepository subcategoryTRepository
      , PaymentMethodTRepository paymentMethodTRepository
      , GenderTRepository genderTRepository
      , DeliveryStatusTRepository deliveryStatusTRepository
    ) {
        _categoryTRepository = categoryTRepository;
        _subcategoryTRepository = subcategoryTRepository;
        _paymentMethodTRepository = paymentMethodTRepository;
        _genderTRepository = genderTRepository;
        _deliveryStatusTRepository = deliveryStatusTRepository;
    }

    #region CategoryType

    public async Task<CategoryTModel?> GetCategoryTypeAsync(CategoryType categoryType) {
        try {
            var categoryTDbo = await _categoryTRepository.FindByConditionAsync(x => x.Id == (int)categoryType);
            if (categoryTDbo is null)
                return null;

            var (_, model) = CategoryTRepository.ToModel(categoryTDbo);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task<CategoryTModel?> GetCategoryTypeAsync(SubcategoryType subcategoryType) {
        try {
            var categoryTListDbo = await _categoryTRepository.GetAllAsync();

            var (isSuccessful, model) = CategoryTRepository.ToModel(categoryTListDbo);
            if (!isSuccessful)
                return null;

            return model.FirstOrDefault(c => c.SubcategoryTModelList.Any(s => s.Type == subcategoryType));
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task<IReadOnlyCollection<CategoryTModel>> GetCategoryTListAsync() {
        try {
            var categoryTListDbo = await _categoryTRepository.GetAllAsync();

            var (_, model) = CategoryTRepository.ToModel(categoryTListDbo);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return Array.Empty<CategoryTModel>();
        }
    }

    #endregion

    #region SubcategoryType

    public async Task<IReadOnlyCollection<SubcategoryTModel>> GetSubcategoryTListAsync() {
        try {
            var subcategoryTListDbo = await _subcategoryTRepository.GetAllAsync();

            var (_, model) = SubcategoryTRepository.ToModel(subcategoryTListDbo);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return Array.Empty<SubcategoryTModel>();
        }
    }

    public async Task<IReadOnlyCollection<SubcategoryTModel>> GetSubcategoryTListAsync(CategoryType categoryType) {
        try {
            var subcategoryTListDbo = await _subcategoryTRepository.FindByConditionListAsync(
                x => x.CategoryTDboId == (int)categoryType
            );

            var (_, model) = SubcategoryTRepository.ToModel(subcategoryTListDbo);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return Array.Empty<SubcategoryTModel>();
        }
    }

    #endregion

    #region PaymentType

    public async Task<IReadOnlyCollection<PaymentMethodTModel>> GetPaymentMethodTListAsync() {
        try {
            var paymentMethodTListDbo = await _paymentMethodTRepository.GetAllAsync();

            var (_, model) = PaymentMethodTRepository.ToModel(paymentMethodTListDbo);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return Array.Empty<PaymentMethodTModel>();
        }
    }

    #endregion

    #region GenderType

    public async Task<IReadOnlyCollection<GenderTModel>> GetGenderTListAsync() {
        try {
            var genderTListDbo = await _genderTRepository.GetAllAsync();

            var (_, model) = GenderTRepository.ToModel(genderTListDbo);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return Array.Empty<GenderTModel>();
        }
    }

    #endregion

    #region DeliveryStatusType

    public async Task<IReadOnlyCollection<DeliveryStatusTModel>> GetDeliveryStatusTListAsync() {
        try {
            var deliveryStatusTListDbo = await _deliveryStatusTRepository.GetAllAsync();

            var (_, models) = DeliveryStatusTRepository.ToModel(deliveryStatusTListDbo);
            return models;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return Array.Empty<DeliveryStatusTModel>();
        }
    }

    #endregion
}