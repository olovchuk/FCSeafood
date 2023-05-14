import {Injectable} from "@angular/core";
import {CommonDataState} from "@common-states/common-data.state";
import {CommonData} from "@common-data/common/common.data";
import {MainSitemapState} from "@common-states/main-sitemap.state";
import {MainMenuItemModel} from "@common-models/main-menu-item.model";
import {CategoryListPopupComponent} from "@modules/components/popups/category-list-popup/category-list-popup.component";

@Injectable({providedIn: 'root'})
export class CommonDataStateService {
  constructor(private commonDataState: CommonDataState,
              private commonData: CommonData,
              private mainSitemapState: MainSitemapState) {
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

    const bindCategoryListResponse = await this.commonData.GetBindCategoryListAsync();
    if (bindCategoryListResponse.isSuccessful)
      this.commonDataState.bindCategoryListModel = bindCategoryListResponse.bindCategoryListModel;

    this.commonDataState.ResolveInit(null);
  }

  initMainMenu(): void {
    this.mainSitemapState.items = [this.product];
  }

  product: MainMenuItemModel = new MainMenuItemModel(
    1,
    'Product',
    '',
    CategoryListPopupComponent
  );
}
