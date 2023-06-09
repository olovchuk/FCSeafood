import { Component, OnInit } from '@angular/core';
import { ItemService } from "@common-services/item.service";
import { ItemModel } from "@common-models/item.model";
import { ShopFiltersStateService } from "@common-services/shop-filters-state/shop-filters-state.service";

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
    await this.applyFilters();
  }

  async applyFilters(): Promise<void> {
    this.itemModels = await this.itemService.getItemByFilterList(await this.shopFiltersStateService.getItemFilter());
  }
}
