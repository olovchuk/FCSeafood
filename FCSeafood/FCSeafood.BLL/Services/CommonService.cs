using FCSeafood.DAL.Auxiliary.Repository;
using FCSeafood.DAL.Common.Repository;

namespace FCSeafood.BLL.Services;

public class CommonService {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(CommonService));

    private readonly CommonMapperHelper _commonMapperHelper;
    private readonly BindCategoryRepository _bindCategoryRepository;
    private readonly CategoryTRepository _categoryTRepository;
    private readonly SubcategoryTRepository _subcategoryTRepository;

    public CommonService(CommonMapperHelper commonMapperHelper, BindCategoryRepository bindCategoryRepository, CategoryTRepository categoryTRepository, SubcategoryTRepository subcategoryTRepository) {
        _commonMapperHelper = commonMapperHelper;
        _bindCategoryRepository = bindCategoryRepository;
        _categoryTRepository = categoryTRepository;
        _subcategoryTRepository = subcategoryTRepository;
    }

#region CategoryType

    public async Task<IReadOnlyCollection<CategoryTModel>> GetCategoryTypeListAsync() {
        try {
            var categoryTListDbo = await _categoryTRepository.GetAllAsync();

            var result = _commonMapperHelper.ToModel(categoryTListDbo);
            return result.success ? result.models : Array.Empty<CategoryTModel>();
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return Array.Empty<CategoryTModel>();
        }
    }

#endregion

#region SubcategoryType

    public async Task<IReadOnlyCollection<SubcategoryTModel>> GetSubcategoryTypeListAsync() {
        try {
            var subcategoryTListDbo = await _subcategoryTRepository.GetAllAsync();

            var result = _commonMapperHelper.ToModel(subcategoryTListDbo);
            return result.success ? result.models : Array.Empty<SubcategoryTModel>();
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return Array.Empty<SubcategoryTModel>();
        }
    }

#endregion

#region BindCategory

    public async Task<IReadOnlyCollection<BindCategoryModel>> GetBindCategoryListAsync() {
        try {
            var bindCategoryListDbos = await _bindCategoryRepository.GetAllAsync();

            var result = _commonMapperHelper.ToModel(bindCategoryListDbos);
            return result.success ? result.models : Array.Empty<BindCategoryModel>();
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return Array.Empty<BindCategoryModel>();
        }
    }

    public async Task<IReadOnlyCollection<BindCategoryModel>> GetBindCategoryListAsync(CategoryType categoryType) {
        try {
            var bindCategoryListDbos = await _bindCategoryRepository.GetByCategoryTypeAsync(categoryType);

            var result = _commonMapperHelper.ToModel(bindCategoryListDbos);
            return result.success ? result.models : Array.Empty<BindCategoryModel>();
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return Array.Empty<BindCategoryModel>();
        }
    }

#endregion
}