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

  priceFrom: number | null = null;
  priceTo: number | null = null;

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
    let price = -1.0;
    if (event.value != null)
      price = event.value;
    await this.shopFiltersStateService.changePriceFrom(price);
  }

  async priceToChange(event: any): Promise<void> {
    let price = -1.0;
    if (event.value != null)
      price = event.value;
    await this.shopFiltersStateService.changePriceTo(price);
  }

  applyFilters() {
    this.applyEvent.emit();
  }

  async refreshFilters() {
    this.priceFrom = null;
    this.priceTo = null;
    await this.shopFiltersStateService.refresh();
    this.applyEvent.emit();
  }
}
