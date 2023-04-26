namespace FCSeafood.BLL.Common;

public class CommonManager {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(CommonManager));

    private readonly CommonService _commonService;

    public CommonManager(CommonService commonService) {
        _commonService = commonService;
    }

    public async Task<CategoryTListResponse> GetCategoryTListAsync() {
        try {
            var categoryTypeListModel = await _commonService.GetCategoryTypeListAsync();
            return new CategoryTListResponse(true, "", categoryTypeListModel);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new CategoryTListResponse(false, "Something goes wrong when retrieving data", Enumerable.Empty<CategoryTypeModel>());
        }
    }

    public async Task<SubCategoryTListResponse> GetSubCategoryTListAsync() {
        try {
            var subCategoryTypeListModel = await _commonService.GetSubCategoryTypeListAsync();
            return new SubCategoryTListResponse(true, "", subCategoryTypeListModel);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new SubCategoryTListResponse(false, "Something goes wrong when retrieving data", Enumerable.Empty<SubCategoryTypeModel>());
        }
    }

    public async Task<SubCategoryTListResponse> GetSubCategoryTListAsync(CategoryTParams categoryTParams) {
        try {
            var bindCategoryListModel = await _commonService.GetBindCategoryListAsync(categoryTParams.CategoryType);
            return new SubCategoryTListResponse(true, "", bindCategoryListModel.Select(x => x.SubCategoryTypeModel));
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new SubCategoryTListResponse(false, "Something goes wrong when retrieving data", Enumerable.Empty<SubCategoryTypeModel>());
        }
    }
}