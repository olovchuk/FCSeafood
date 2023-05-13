import {Injectable} from "@angular/core";
import {CommonDataState} from "@common-states/common-data.state";
import {CommonData} from "@common-data/common/common.data";
import {SubcategoryTypeRequest} from "@common-data/common/models/request/subcategory-type.request";
import {CategoryType} from "@common-enums/category.type";
import {SubcategoryTModel} from "@common-data/common/models/common/subcategory-type.model";

@Injectable({providedIn: 'root'})
export class CommonDataStateService {
  constructor(private commonDataState: CommonDataState,
              private commonData: CommonData) {
  }

  get state(): CommonDataState {
    return this.commonDataState;
  }

  async init(): Promise<void> {
    const categoryTListResponse = await this.commonData.GetCategoryListAsync();
    if (categoryTListResponse.isSuccessful)
      this.commonDataState.categoryTListModel = categoryTListResponse.categoryTListModel;

    const subcategoryTypeListResponse = await this.commonData.GetSubcategoryListAsync();
    if (subcategoryTypeListResponse.isSuccessful)
      this.commonDataState.subcategoryTListModel = subcategoryTypeListResponse.subcategoryTListModel;
  }

  async getSubcategoryByCategoryListAsync(categoryType: CategoryType): Promise<SubcategoryTModel[]> {
    let subcategoryTypeRequest = new SubcategoryTypeRequest();
    subcategoryTypeRequest.categoryType = categoryType;
    const subcategoryTypeListResponse = await this.commonData.GetSubcategoryByCategoryListAsync(subcategoryTypeRequest);
    if (subcategoryTypeListResponse.isSuccessful)
      return subcategoryTypeListResponse.subcategoryTListModel;
    return [];
  }
}
