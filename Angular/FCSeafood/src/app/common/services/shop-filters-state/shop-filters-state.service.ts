import {Injectable} from "@angular/core";
import {ShopFiltersState} from "@common-states/shop-filters.state";
import {LocalStorageHelper} from "@common-helpers/local-storage.helper";
import {CommonDataStateService} from "@common-services/common-data-state/common-data-state.service";
import {CategoryType} from "@common-enums/category.type";
import {SubcategoryType} from "@common-enums/sub-category.type";
import {SortDirectionType} from "@common-enums/sort-direction.type";

export const SHOP_FILTERS = 'shop_filters';

@Injectable({providedIn: 'root'})
export class ShopFiltersStateService {
  constructor(private shopFiltersState: ShopFiltersState,
              private commonDataStateService: CommonDataStateService) {
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
      this.shopFiltersState.selectedPriceSorted = shopFiltersLS.selectedPriceSorted;
    } else {
      this.shopFiltersState.categoryTList = await this.commonDataStateService.getCategoryTListAsync()
      this.shopFiltersState.selectedCategoryType = this.shopFiltersState.categoryTList[0]?.type;
      this.shopFiltersState.subcategoryTList = await this.commonDataStateService.getSubcategoryTListAsync(this.shopFiltersState.selectedCategoryType);
      this.shopFiltersState.selectedSubcategoryType = this.shopFiltersState.subcategoryTList[0]?.type;
      this.shopFiltersState.sortDirectionTList = [SortDirectionType.Ascending, SortDirectionType.Descending];
      this.shopFiltersState.selectedPriceSorted = SortDirectionType.Ascending;
    }

    this.shopFiltersState.ResolveInit(null);
    return this.shopFiltersState;
  }

  async changeCategory(categoryType: CategoryType): Promise<void> {
    this.shopFiltersState.selectedCategoryType = categoryType;
    this.shopFiltersState.subcategoryTList = await this.commonDataStateService.getSubcategoryTListAsync(this.shopFiltersState.selectedCategoryType);
    this.shopFiltersState.selectedSubcategoryType = this.shopFiltersState.subcategoryTList[0]?.type;
    this.save();
  }

  async changeSubcategory(subcategoryType: SubcategoryType): Promise<void> {
    this.shopFiltersState.selectedSubcategoryType = subcategoryType;
    this.save();
  }

  changePriceSorted(sortDirectionType: SortDirectionType) {
    this.shopFiltersState.selectedPriceSorted = sortDirectionType;
    this.save();
  }

  save() {
    LocalStorageHelper.Set<ShopFiltersState>(SHOP_FILTERS, this.shopFiltersState);
  }
}
