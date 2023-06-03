import { Component, OnInit } from '@angular/core';
import { ItemService } from "@common-services/item.service";
import { ItemModel } from "@common-models/item.model";
import { ItemFilterRequest } from "@common-data/item/http/request/item-filter.request";
import { CategoryType } from "@common-enums/category.type";
import { SubcategoryType } from "@common-enums/subcategory.type";

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.scss']
})
export class ItemListComponent implements OnInit {
  itemModels: ItemModel[] = [];

  constructor(private itemService: ItemService) {
  }

  async ngOnInit(): Promise<void> {
    let itemFilterRequest: ItemFilterRequest = {
      categoryType: CategoryType.Fish,
      subcategoryType: SubcategoryType.SeaFish,
      priceFrom: 1,
      priceTo: 100
    };

    this.itemModels = await this.itemService.getItemByFilterList(itemFilterRequest);
  }
}
