import {Component} from '@angular/core';
import {ShopFiltersStateService} from "@common-services/shop-filters-state/shop-filters-state.service";
import {RouteHelper} from "@common-helpers/route.helper";
import {CategoryType} from "@common-enums/category.type";
import {SubcategoryType} from "@common-enums/sub-category.type";
import {SortDirectionType} from "@common-enums/sort-direction.type";

@Component({
  selector: 'shop-full-size-filter',
  templateUrl: './full-size-filter.component.html',
  styleUrls: ['./full-size-filter.component.scss']
})
export class FullSizeFilterComponent {
  protected readonly SortDirectionType = SortDirectionType;

  constructor(public routeHelper: RouteHelper,
              public shopFiltersStateService: ShopFiltersStateService) {
  }

  priceSortDirectionChange(sortDirectionType: SortDirectionType) {
    if (sortDirectionType)
      this.shopFiltersStateService.changePriceSorted(sortDirectionType);
  }

  async categoryTypeChange(categoryType: CategoryType): Promise<void> {
    await this.shopFiltersStateService.changeCategory(categoryType);
  }

  async subcategoryTypeChange(subcategoryType: SubcategoryType): Promise<void> {
    await this.shopFiltersStateService.changeSubcategory(subcategoryType);
  }

  applyFilters() {
  }
}
