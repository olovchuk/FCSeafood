namespace FCSeafood.BLL.Common;

public class CommonManager {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                     .CreateLogger(typeof(CommonManager));

    private readonly CommonService _commonService;

    public CommonManager(CommonService commonService) {
        _commonService = commonService;
    }

    public async Task<CategoryTResponse> GetCategoryTypeAsync(CategoryTParams categoryTParams) {
        try {
            var categoryTModel = await _commonService.GetCategoryTypeAsync(categoryTParams.CategoryType);
            return new CategoryTResponse(true, "", categoryTModel);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new CategoryTResponse(false, ErrorMessage.Common.ErrorRetrievingData, null);
        }
    }

    public async Task<CategoryTResponse> GetCategoryTypeAsync(SubcategoryTParams subcategoryTParams) {
        try {
            var categoryTModel = await _commonService.GetCategoryTypeAsync(subcategoryTParams.SubcategoryType);
            return new CategoryTResponse(true, "", categoryTModel);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new CategoryTResponse(false, ErrorMessage.Common.ErrorRetrievingData, null);
        }
    }

    public async Task<CategoryTListResponse> GetCategoryTListAsync() {
        try {
            var categoryTListModel = await _commonService.GetCategoryTListAsync();
            return new CategoryTListResponse(true, "", categoryTListModel);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new CategoryTListResponse(false, ErrorMessage.Common.ErrorRetrievingData
                                           , Enumerable.Empty<CategoryTModel>());
        }
    }

    public async Task<SubcategoryTListResponse> GetSubcategoryTListAsync() {
        try {
            var subcategoryTListModel = await _commonService.GetSubcategoryTListAsync();
            return new SubcategoryTListResponse(true, "", subcategoryTListModel);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new SubcategoryTListResponse(false, ErrorMessage.Common.ErrorRetrievingData
                                              , Enumerable.Empty<SubcategoryTModel>());
        }
    }

    public async Task<SubcategoryTListResponse> GetSubcategoryTListAsync(CategoryTParams categoryTParams) {
        try {
            var subcategoryTListModel = await _commonService.GetSubcategoryTListAsync(categoryTParams.CategoryType);
            return new SubcategoryTListResponse(true, "", subcategoryTListModel);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new SubcategoryTListResponse(false, ErrorMessage.Common.ErrorRetrievingData
                                              , Enumerable.Empty<SubcategoryTModel>());
        }
    }
}