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
import {BindCategoryModel} from "@common-data/common/models/common/BindCategoryModel";

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

  async getBindCategoryListAsync(): Promise<BindCategoryModel[]> {
    const response = await this.commonData.GetBindCategoryListAsync();
    if (!response.isSuccessful) {
      this.matSnackBar.open(response.message);
      return [];
    }

    return response.bindCategoryListModel;
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
