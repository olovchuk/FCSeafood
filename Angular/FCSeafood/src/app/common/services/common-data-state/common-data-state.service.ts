import {Injectable} from "@angular/core";
import {CommonDataState} from "@common-states/common-data.state";
import {CommonData} from "@common-data/common/common.data";

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

    const subcategoryTypeListResponse = await this.commonData.GetSubCategoryListAsync();
    if (subcategoryTypeListResponse.isSuccessful)
      this.commonDataState.subcategoryTListModel = subcategoryTypeListResponse.subcategoryTListModel;
  }
}
