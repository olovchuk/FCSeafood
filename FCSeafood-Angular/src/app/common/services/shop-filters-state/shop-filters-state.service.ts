import { Injectable } from "@angular/core";
import { LocalStorageHelper } from "@common-helpers/local-storage.helper";
import { ShopFiltersState } from "@common-states/shop-filters.state";
import { CommonService } from "@common-services/common.service";
import { CategoryType } from "@common-enums/category.type";
import { SubcategoryType } from "@common-enums/subcategory.type";
import { SortDirectionType } from "@common-enums/sort-direction.type";

export const SHOP_FILTERS = 'shop_filters';

@Injectable({providedIn: 'root'})
export class ShopFiltersStateService {
  isInit: boolean = false;

  constructor(private shopFiltersState: ShopFiltersState,
              private commonService: CommonService) {
  }

  get state(): ShopFiltersState {
    return this.shopFiltersState;
  }

  async init(): Promise<ShopFiltersState> {
    const shopFiltersLS = LocalStorageHelper.Get<ShopFiltersState>(SHOP_FILTERS);
    if (shopFiltersLS) {
      this.shopFiltersState.categoryTList = shopFiltersLS.categoryTList;
      this.shopFiltersState.selectedCategoryType = shopFiltersLS.selectedCategoryType;
      this.shopFiltersState.subcategoryTList = shopFiltersLS.subcategoryTList;
      this.shopFiltersState.selectedSubcategoryType = shopFiltersLS.selectedSubcategoryType;
      this.shopFiltersState.sortDirectionTList = shopFiltersLS.sortDirectionTList;
      this.shopFiltersState.selectedPriceSortDirectionType = shopFiltersLS.selectedPriceSortDirectionType;
    }
    else {
      this.shopFiltersState.categoryTList = await this.commonService.getCategoryTListAsync();
      this.shopFiltersState.selectedCategoryType = this.shopFiltersState.categoryTList[0]?.type;
      this.shopFiltersState.subcategoryTList = this.shopFiltersState.categoryTList[this.shopFiltersState.selectedCategoryType].subcategoryTModelList;
      this.shopFiltersState.selectedSubcategoryType = this.shopFiltersState.subcategoryTList[0]?.type;
      this.shopFiltersState.sortDirectionTList = [
        {type: SortDirectionType.Ascending, name: SortDirectionType[SortDirectionType.Ascending]},
        {type: SortDirectionType.Descending, name: SortDirectionType[SortDirectionType.Descending]}
      ]
      this.shopFiltersState.selectedPriceSortDirectionType = SortDirectionType.Ascending;
    }

    this.isInit = true;
    this.shopFiltersState.ResolveInit(null);
    return this.shopFiltersState;
  }

  async changeCategory(categoryType: CategoryType): Promise<void> {
    if (!this.isInit)
      await this.init();

    this.shopFiltersState.selectedCategoryType = categoryType;
    this.shopFiltersState.subcategoryTList = await this.commonService.getSubcategoryTListAsync(this.shopFiltersState.selectedCategoryType);
    this.shopFiltersState.selectedSubcategoryType = this.shopFiltersState.subcategoryTList[0]?.type;
    this.save();
  }

  async changeSubcategory(subcategoryType: SubcategoryType): Promise<void> {
    if (!this.isInit)
      await this.init();

    this.shopFiltersState.selectedSubcategoryType = subcategoryType;
    this.save();
  }

  async changePriceSorted(sortDirectionType: SortDirectionType): Promise<void> {
    if (!this.isInit)
      await this.init();

    this.shopFiltersState.selectedPriceSortDirectionType = sortDirectionType;
    this.save();
  }

  save() {
    LocalStorageHelper.Set<ShopFiltersState>(SHOP_FILTERS, this.shopFiltersState);
  }
}
