using FCSeafood.DAL.Context;
using FCSeafood.DAL.Common.Repository;

namespace FCSeafood.BLL.Common;

public class CommonManager {
    private readonly ILogger log = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(CommonManager));

    private readonly CategoryTypeRepository _categoryTypeRepository;
    private readonly CommonMapperHelper _commonMapperHelper;

    public CommonManager(CategoryTypeRepository categoryTypeRepository, CommonMapperHelper commonMapperHelper) {
        _categoryTypeRepository = categoryTypeRepository;
        _commonMapperHelper = commonMapperHelper;
    }

    public async Task<GetCategoryTypeListResponse> GetCategoryTypeListAsync() {
        try {
            var categoryTypeModels = await _categoryTypeRepository.GetAll();
            var listResult = _commonMapperHelper.ToModel(categoryTypeModels);
            if (listResult is null) return new GetCategoryTypeListResponse(false, "Something goes wrong when retrieving categories", null);
            return new GetCategoryTypeListResponse(true, "", listResult);
        } catch (Exception ex) {
            log.LogError($"Failed to get category type list;\r\nError: [{ex.Message}]");
            return new GetCategoryTypeListResponse(false, "Something goes wrong when retrieving categories", null);
        }
    }
}