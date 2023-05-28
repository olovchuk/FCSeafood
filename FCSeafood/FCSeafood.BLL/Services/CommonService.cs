using FCSeafood.DAL.Common.Repository;

namespace FCSeafood.BLL.Services;

public class CommonService {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(CommonService));

    private readonly CategoryTRepository _categoryTRepository;
    private readonly SubcategoryTRepository _subcategoryTRepository;

    public CommonService(CategoryTRepository categoryTRepository, SubcategoryTRepository subcategoryTRepository) {
        _categoryTRepository = categoryTRepository;
        _subcategoryTRepository = subcategoryTRepository;
    }

#region CategoryType

    public async Task<CategoryTModel?> GetCategoryTypeAsync(CategoryType categoryType) {
        try {
            var categoryTDbo = await _categoryTRepository.FindByConditionAsync(x => x.Id == (int)categoryType);
            if (categoryTDbo is null) return null;

            var result = CategoryTRepository.ToModel(categoryTDbo);
            return result.success ? result.model : null;
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public async Task<CategoryTModel?> GetCategoryTypeAsync(SubcategoryType subcategoryType) {
        try {
            var categoryTListDbo = await _categoryTRepository.GetAllAsync();

            var result = CategoryTRepository.ToModel(categoryTListDbo);
            return !result.success ? null : result.models.FirstOrDefault(c => c.SubcategoryTModelList.Any(s => s.Type == subcategoryType));
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public async Task<IReadOnlyCollection<CategoryTModel>> GetCategoryTListAsync() {
        try {
            var categoryTListDbo = await _categoryTRepository.GetAllAsync();

            var result = CategoryTRepository.ToModel(categoryTListDbo);
            return result.success ? result.models : Array.Empty<CategoryTModel>();
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return Array.Empty<CategoryTModel>();
        }
    }

#endregion

#region SubcategoryType

    public async Task<IReadOnlyCollection<SubcategoryTModel>> GetSubcategoryTListAsync() {
        try {
            var subcategoryTListDbo = await _subcategoryTRepository.GetAllAsync();

            var result = SubcategoryTRepository.ToModel(subcategoryTListDbo);
            return result.success ? result.models : Array.Empty<SubcategoryTModel>();
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return Array.Empty<SubcategoryTModel>();
        }
    }

    public async Task<IReadOnlyCollection<SubcategoryTModel>> GetSubcategoryTListAsync(CategoryType categoryType) {
        try {
            var subcategoryTListDbo = await _subcategoryTRepository.FindByConditionListAsync(x => x.CategoryTDboId == (int)categoryType);

            var result = SubcategoryTRepository.ToModel(subcategoryTListDbo);
            return result.success ? result.models : Array.Empty<SubcategoryTModel>();
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return Array.Empty<SubcategoryTModel>();
        }
    }

#endregion
}