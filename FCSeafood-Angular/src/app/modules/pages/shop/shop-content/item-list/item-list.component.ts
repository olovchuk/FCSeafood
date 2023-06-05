import { Component, OnInit } from '@angular/core';
import { ItemService } from "@common-services/item.service";
import { ItemModel } from "@common-models/item.model";
import { ItemFilterRequest } from "@common-data/item/http/request/item-filter.request";
import { ShopFiltersStateService } from "@common-services/shop-filters-state/shop-filters-state.service";
import { CategoryType } from "@common-enums/category.type";
import { SubcategoryType } from "@common-enums/subcategory.type";
import { SortDirectionType } from "@common-enums/sort-direction.type";

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.scss']
})
export class ItemListComponent implements OnInit {
  itemModels: ItemModel[] = [];

  constructor(private itemService: ItemService,
              private shopFiltersStateService: ShopFiltersStateService) {
  }

  async ngOnInit(): Promise<void> {
    let itemFilterRequest: ItemFilterRequest = {
      categoryType: CategoryType.Fish,
      subcategoryType: SubcategoryType.SeaFish,
      sortDirectionType: SortDirectionType.NoSort,
      priceFrom: -1,
      priceTo: -1
    };

    this.itemModels = await this.itemService.getItemByFilterList(itemFilterRequest);
  }

  async applyFilters(): Promise<void> {
    let itemFilterRequest: ItemFilterRequest = {
      categoryType: this.shopFiltersStateService.state.selectedCategoryType,
      subcategoryType: this.shopFiltersStateService.state.selectedSubcategoryType,
      sortDirectionType: this.shopFiltersStateService.state.selectedPriceSortDirectionType,
      priceFrom: this.shopFiltersStateService.state.priceFrom,
      priceTo: this.shopFiltersStateService.state.priceTo
    };

    this.itemModels = await this.itemService.getItemByFilterList(itemFilterRequest);
  }
}
