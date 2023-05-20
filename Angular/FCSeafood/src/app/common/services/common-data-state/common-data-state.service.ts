import {Injectable} from "@angular/core";
import {CommonDataState} from "@common-states/common-data.state";
import {CommonData} from "@common-data/common/common.data";
import {MainSitemapState} from "@common-states/main-sitemap.state";
import {MainMenuItemModel} from "@common-models/main-menu-item.model";
import {CategoryListPopupComponent} from "@modules/components/popups/category-list-popup/category-list-popup.component";
import {SubcategoryTypeRequest} from "@common-data/common/models/request/subcategory-type.request";
import {CategoryType} from "@common-enums/category.type";
import {MatSnackBar} from "@angular/material/snack-bar";
import {CategoryTModel} from "@common-data/common/models/common/category-type.model";
import {SubcategoryTModel} from "@common-data/common/models/common/subcategory-type.model";

@Injectable({providedIn: 'root'})
export class CommonDataStateService {
  constructor(private commonDataState: CommonDataState,
              private commonData: CommonData,
              private mainSitemapState: MainSitemapState,
              private matSnackBar: MatSnackBar) {
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

  async getCategoryTListAsync(): Promise<CategoryTModel[]> {
    const response = await this.commonData.GetCategoryListAsync();
    if (!response.isSuccessful) {
      this.matSnackBar.open(response.message);
      return [];
    }

    return response.categoryTListModel;
  }

  async getSubcategoryTListAsync(category: CategoryType): Promise<SubcategoryTModel[]> {
    let subcategoryTypeRequest = new SubcategoryTypeRequest();
    subcategoryTypeRequest.categoryType = category;

    const response = await this.commonData.GetSubcategoryByCategoryListAsync(subcategoryTypeRequest);
    if (!response.isSuccessful) {
      this.matSnackBar.open(response.message);
      return [];
    }

    return response.subcategoryTListModel;
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
