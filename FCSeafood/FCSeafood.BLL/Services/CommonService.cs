using FCSeafood.DAL.Auxiliary.Repository;
using FCSeafood.DAL.Common.Repository;

namespace FCSeafood.BLL.Services;

public class CommonService {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(CommonService));

    private readonly CommonMapperHelper _commonMapperHelper;
    private readonly BindCategoryRepository _bindCategoryRepository;
    private readonly CategoryTRepository _categoryTRepository;
    private readonly SubCategoryTRepository _subCategoryTRepository;

    public CommonService(CommonMapperHelper commonMapperHelper, BindCategoryRepository bindCategoryRepository, CategoryTRepository categoryTRepository, SubCategoryTRepository subCategoryTRepository) {
        _commonMapperHelper = commonMapperHelper;
        _bindCategoryRepository = bindCategoryRepository;
        _categoryTRepository = categoryTRepository;
        _subCategoryTRepository = subCategoryTRepository;
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

#region SubCategoryType

    public async Task<IReadOnlyCollection<SubCategoryTModel>> GetSubCategoryTypeListAsync() {
        try {
            var subCategoryTListDbo = await _subCategoryTRepository.GetAllAsync();

            var result = _commonMapperHelper.ToModel(subCategoryTListDbo);
            return result.success ? result.models : Array.Empty<SubCategoryTModel>();
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return Array.Empty<SubCategoryTModel>();
        }
    }

#endregion

#region BindCategory

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