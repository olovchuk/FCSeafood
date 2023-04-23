using FCSeafood.DAL.Auxiliary.Repository;
using FCSeafood.DAL.Context;
using FCSeafood.DAL.Common.Repository;

namespace FCSeafood.BLL.Common;

public class CommonManager {
    private readonly ILogger log = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(CommonManager));

    private readonly CommonMapperHelper _commonMapperHelper;
    private readonly CategoryTypeRepository _categoryTypeRepository;
    private readonly SubCategoryTypeRepository _subCategoryTypeRepository;
    private readonly BindCategoryRepository _bindCategoryRepository;

    public CommonManager(CategoryTypeRepository categoryTypeRepository, CommonMapperHelper commonMapperHelper, SubCategoryTypeRepository subCategoryTypeRepository, BindCategoryRepository bindCategoryRepository) {
        _commonMapperHelper = commonMapperHelper;
        _categoryTypeRepository = categoryTypeRepository;
        _subCategoryTypeRepository = subCategoryTypeRepository;
        _bindCategoryRepository = bindCategoryRepository;
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

    public async Task<GetSubCategoryTypeResponse> GetSubCategoryTypeListAsync() {
        try {
            var dbos = await _subCategoryTypeRepository.GetAll();
            var listModels = _commonMapperHelper.ToModel(dbos);
            if (listModels is null) return new GetSubCategoryTypeResponse(false, "Something goes wrong when retrieving categories", null);
            return new GetSubCategoryTypeResponse(true, "", listModels);
        } catch (Exception ex) {
            log.LogError($"Failed to get category type list;\r\nError: [{ex.Message}]");
            return new GetSubCategoryTypeResponse(false, "Something goes wrong when retrieving sub categories", null);
        }
    }

    public async Task<GetSubCategoryTypeResponse> GetSubCategoryTypeByCategoryTypeListAsync(GetSubCategoryTypeByCategoryTypeParams subCategoryTypeByCategoryTypeParams) {
        try {
            var dbos = await _bindCategoryRepository.GetByCategoryType(subCategoryTypeByCategoryTypeParams.CategoryType);
            var s = dbos.Select(x => x.SubCategoryType).ToList();
            // TODO: Mapper
            return new GetSubCategoryTypeResponse(true, "", new List<SubCategoryTypeModel>());
        } catch (Exception ex) {
            log.LogError($"Failed to get category type list;\r\nError: [{ex.Message}]");
            return new GetSubCategoryTypeResponse(false, "Something goes wrong when retrieving sub categories", null);
        }
    }
}