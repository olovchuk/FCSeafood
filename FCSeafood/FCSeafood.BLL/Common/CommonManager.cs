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
            var categoryTypeModels = await _categoryTypeRepository.GetAllAsync();
            var result = _commonMapperHelper.ToModel(categoryTypeModels);
            if (!result.success) return new GetCategoryTypeListResponse(false, "Something goes wrong when retrieving categories", Enumerable.Empty<CategoryTypeModel>());
            return new GetCategoryTypeListResponse(true, "", result.models);
        } catch (Exception ex) {
            log.LogError($"Failed to get category type list;\r\nError: [{ex.Message}]");
            return new GetCategoryTypeListResponse(false, "Something goes wrong when retrieving categories", Enumerable.Empty<CategoryTypeModel>());
        }
    }

    public async Task<GetSubCategoryTypeResponse> GetSubCategoryTypeListAsync() {
        try {
            var dbos = await _subCategoryTypeRepository.GetAll();
            var result = _commonMapperHelper.ToModel(dbos);
            if (!result.success) return new GetSubCategoryTypeResponse(false, "Something goes wrong when retrieving categories", Enumerable.Empty<SubCategoryTypeModel>());
            return new GetSubCategoryTypeResponse(true, "", result.models);
        } catch (Exception ex) {
            log.LogError($"Failed to get category type list;\r\nError: [{ex.Message}]");
            return new GetSubCategoryTypeResponse(false, "Something goes wrong when retrieving sub categories", Enumerable.Empty<SubCategoryTypeModel>());
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