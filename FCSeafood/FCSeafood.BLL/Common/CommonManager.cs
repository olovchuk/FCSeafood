namespace FCSeafood.BLL.Common;

public class CommonManager {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(CommonManager));

    private readonly CommonService _commonService;

    public CommonManager(CommonService commonService) {
        _commonService = commonService;
    }

    public async Task<GetCategoryTypeListResponse> GetCategoryTypeListAsync() {
        try {
            var categoryTypeListModel = await _commonService.GetCategoryTypeListAsync();
            return new GetCategoryTypeListResponse(true, "", categoryTypeListModel);
        } catch (Exception ex) {
            _loggger.LogError($"An error occurred during management;\r\nError: [{ex.Message}]");
            return new GetCategoryTypeListResponse(false, "Something goes wrong when retrieving data", Enumerable.Empty<CategoryTypeModel>());
        }
    }

    public async Task<GetSubCategoryTypeResponse> GetSubCategoryTypeListAsync() {
        try {
            var subCategoryTypeListModel = await _commonService.GetSubCategoryTypeListAsync();
            return new GetSubCategoryTypeResponse(true, "", subCategoryTypeListModel);
        } catch (Exception ex) {
            _loggger.LogError($"An error occurred during management;\r\nError: [{ex.Message}]");
            return new GetSubCategoryTypeResponse(false, "Something goes wrong when retrieving data", Enumerable.Empty<SubCategoryTypeModel>());
        }
    }

    public async Task<GetSubCategoryTypeResponse> GetSubCategoryTypeByCategoryTypeListAsync(GetSubCategoryTypeByCategoryTypeParams subCategoryTypeByCategoryTypeParams) {
        try {
            var bindCategoryListModel = await _commonService.GetBindCategoryListAsync(subCategoryTypeByCategoryTypeParams.CategoryType);
            return new GetSubCategoryTypeResponse(true, "", bindCategoryListModel.Select(x => x.SubCategoryTypeModel));
        } catch (Exception ex) {
            _loggger.LogError($"An error occurred during management;\r\nError: [{ex.Message}]");
            return new GetSubCategoryTypeResponse(false, "Something goes wrong when retrieving data", Enumerable.Empty<SubCategoryTypeModel>());
        }
    }
}