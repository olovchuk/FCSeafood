namespace FCSeafood.BLL.Common;

public class CommonManager {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(CommonManager));

    private readonly CommonService _commonService;

    public CommonManager(CommonService commonService) {
        _commonService = commonService;
    }

    public async Task<CategoryTListResponse> GetCategoryTListAsync() {
        try {
            var categoryTListModel = await _commonService.GetCategoryTypeListAsync();
            return new CategoryTListResponse(true, "", categoryTListModel);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new CategoryTListResponse(false, "Something goes wrong when retrieving data", Enumerable.Empty<CategoryTModel>());
        }
    }

    public async Task<SubcategoryTListResponse> GetSubcategoryTListAsync() {
        try {
            var subcategoryTListModel = await _commonService.GetSubcategoryTypeListAsync();
            return new SubcategoryTListResponse(true, "", subcategoryTListModel);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new SubcategoryTListResponse(false, "Something goes wrong when retrieving data", Enumerable.Empty<SubcategoryTModel>());
        }
    }

    public async Task<SubcategoryTListResponse> GetSubcategoryTListAsync(CategoryTParams categoryTParams) {
        try {
            var bindCategoryListModel = await _commonService.GetBindCategoryListAsync(categoryTParams.CategoryType);
            return new SubcategoryTListResponse(true, "", bindCategoryListModel.Select(x => x.SubcategoryTModel));
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new SubcategoryTListResponse(false, "Something goes wrong when retrieving data", Enumerable.Empty<SubcategoryTModel>());
        }
    }

    public async Task<BindCategoryListResponse> GetBindCategoryListAsync() {
        try {
            var bindCategoryListModel = await _commonService.GetBindCategoryListAsync();
            return new BindCategoryListResponse(true, "", bindCategoryListModel);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new BindCategoryListResponse(false, "Something goes wrong when retrieving data", Enumerable.Empty<BindCategoryModel>());
        }
    }
}