import { Injectable } from "@angular/core";
import { ItemData } from "@common-data/item/item.data";
import { ItemModel } from "@common-models/item.model";
import { ItemFilterRequest } from "@common-data/item/http/request/item-filter.request";

@Injectable({providedIn: 'root'})
export class ItemService {
  constructor(private itemData: ItemData) {
  }

  async getItemByFilterList(itemFilterRequest: ItemFilterRequest): Promise<ItemModel[]> {
    const response = await this.itemData.getItemByFilterList(itemFilterRequest);
    if (!response.isSuccessful)
      return [];

    return response.itemModels;
  }
}
