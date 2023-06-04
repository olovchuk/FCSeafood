import { Component, EventEmitter, Output } from '@angular/core';
import { ShopFiltersStateService } from "@common-services/shop-filters-state/shop-filters-state.service";
import { RouteHelper } from "@common-helpers/route.helper";
import { SortDirectionType } from "@common-enums/sort-direction.type";
import { CategoryType } from "@common-enums/category.type";

@Component({
  selector: 'shop-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent {
  @Output('applyEvent') applyEvent = new EventEmitter<number>();

  protected readonly SortDirectionType = SortDirectionType;
  protected readonly CategoryType = CategoryType;

  constructor(public routeHelper: RouteHelper,
              public shopFiltersStateService: ShopFiltersStateService) {
  }

  async priceSortDirectionChange(event: any): Promise<void> {
    let sortDirectionType = event.checked ? SortDirectionType.Descending : SortDirectionType.Ascending;
    await this.shopFiltersStateService.changePriceSorted(sortDirectionType);
  }

  async categoryTypeChange(event: any): Promise<void> {
    await this.shopFiltersStateService.changeCategory(event.value);
  }

  async subcategoryTypeChange(event: any): Promise<void> {
    await this.shopFiltersStateService.changeSubcategory(event.value);
  }

  async priceFromChange(event: any): Promise<void> {
    await this.shopFiltersStateService.changePriceFrom(event.value);
  }

  async priceToChange(event: any): Promise<void> {
    await this.shopFiltersStateService.changePriceTo(event.value);
  }

  applyFilters() {
    this.applyEvent.emit();
  }

  async refreshFilters() {
    await this.shopFiltersStateService.refresh();
  }
}
