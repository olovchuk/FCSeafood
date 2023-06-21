import { EventEmitter, Injectable } from "@angular/core";
import { LocalStorageHelper } from "@common-helpers/local-storage.helper";
import { ShopFiltersState } from "@common-states/shop-filters.state";
import { CommonService } from "@common-services/common.service";
import { CategoryType } from "@common-enums/category.type";
import { SubcategoryType } from "@common-enums/subcategory.type";
import { SortDirectionType } from "@common-enums/sort-direction.type";
import { ItemFilterRequest } from "@common-data/item/http/request/item-filter.request";

export const SHOP_FILTERS = 'shop_filters';

@Injectable({providedIn: 'root'})
export class ShopFiltersStateService {
  isInit: boolean = false;
  isDefault: boolean = true;

  applyFiltersSubscription$: EventEmitter<void> = new EventEmitter<void>();

  constructor(private shopFiltersState: ShopFiltersState,
              private commonService: CommonService) {
  }

  get state(): ShopFiltersState {
    return this.shopFiltersState;
  }

  async getItemFilter(): Promise<ItemFilterRequest> {
    if (!this.isInit)
      await this.init();

    return {
      categoryType: this.state.selectedCategoryType,
      subcategoryType: this.state.selectedSubcategoryType,
      sortDirectionType: this.state.selectedPriceSortDirectionType,
      priceFrom: this.state.priceFrom,
      priceTo: this.state.priceTo
    };
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
      this.shopFiltersState.priceFrom = shopFiltersLS.priceFrom;
      this.shopFiltersState.priceTo = shopFiltersLS.priceTo;
      this.isDefault = false;
    } else {
      this.shopFiltersState.categoryTList = await this.commonService.getCategoryTList();
      this.shopFiltersState.selectedCategoryType = this.shopFiltersState.categoryTList[0]?.type;
      this.shopFiltersState.subcategoryTList = this.shopFiltersState.categoryTList[0].subcategoryTModelList;
      this.shopFiltersState.selectedSubcategoryType = this.shopFiltersState.subcategoryTList[0]?.type;
      this.shopFiltersState.sortDirectionTList = [
        {type: SortDirectionType.Ascending, name: SortDirectionType[SortDirectionType.Ascending]},
        {type: SortDirectionType.Descending, name: SortDirectionType[SortDirectionType.Descending]}
      ]
      this.shopFiltersState.selectedPriceSortDirectionType = SortDirectionType.Ascending;
      this.shopFiltersState.priceFrom = -1;
      this.shopFiltersState.priceTo = -1;
      this.isDefault = true;
    }

    this.isInit = true;
    this.shopFiltersState.ResolveInit(null);
    return this.shopFiltersState;
  }

  async refresh(): Promise<void> {
    LocalStorageHelper.Remove(SHOP_FILTERS);
    await this.init();
  }

  async changeCategory(categoryType: CategoryType): Promise<void> {
    if (!this.isInit)
      await this.init();

    this.shopFiltersState.selectedCategoryType = categoryType;
    this.shopFiltersState.subcategoryTList = await this.commonService.getSubcategoryTList(this.shopFiltersState.selectedCategoryType);
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

  async changePriceFrom(price: number): Promise<void> {
    if (!this.isInit)
      await this.init();

    this.shopFiltersState.priceFrom = price;
    this.save();
  }

  async changePriceTo(price: number): Promise<void> {
    if (!this.isInit)
      await this.init();

    this.shopFiltersState.priceTo = price;
    this.save();
  }

  save() {
    LocalStorageHelper.Set<ShopFiltersState>(SHOP_FILTERS, this.shopFiltersState);
    this.isDefault = false;
  }
}
