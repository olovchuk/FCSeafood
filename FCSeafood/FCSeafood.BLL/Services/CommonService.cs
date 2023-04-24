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

    public async Task<IReadOnlyCollection<CategoryTypeModel>> GetCategoryTypeListAsync() {
        try {
            var categoryTypeListDbo = await _categoryTRepository.GetAllAsync();

            var result = _commonMapperHelper.ToModel(categoryTypeListDbo);
            return result.success ? result.models : Array.Empty<CategoryTypeModel>();
        } catch (Exception ex) {
            _loggger.LogError($"An error occurred during a service operation;\r\nError: [{ex.Message}]");
            return Array.Empty<CategoryTypeModel>();
        }
    }

#endregion

#region SubCategoryType

    public async Task<IReadOnlyCollection<SubCategoryTypeModel>> GetSubCategoryTypeListAsync() {
        try {
            var subCategoryTypeListDbo = await _subCategoryTRepository.GetAllAsync();

            var result = _commonMapperHelper.ToModel(subCategoryTypeListDbo);
            return result.success ? result.models : Array.Empty<SubCategoryTypeModel>();
        } catch (Exception ex) {
            _loggger.LogError($"An error occurred during a service operation;\r\nError: [{ex.Message}]");
            return Array.Empty<SubCategoryTypeModel>();
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
            _loggger.LogError($"An error occurred during a service operation;\r\nError: [{ex.Message}]");
            return Array.Empty<BindCategoryModel>();
        }
    }

#endregion
}