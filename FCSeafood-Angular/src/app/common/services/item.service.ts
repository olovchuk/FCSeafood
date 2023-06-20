import { Injectable } from "@angular/core";
import { ItemData } from "@common-data/item/item.data";
import { ItemModel } from "@common-models/item.model";
import { ItemFilterRequest } from "@common-data/item/http/request/item-filter.request";
import { ItemCodeRequest } from "@common-data/item/http/request/item-code.request";
import { UserIdRequest } from "@common-data/user-information/http/request/user-id.request";
import { RatingType } from "@common-enums/rating.type";
import { GetItemRatingRequest } from "@common-data/item/http/request/get-item-rating.request";
import { SetItemRatingRequest } from "@common-data/item/http/request/set-item-rating.request";

@Injectable({providedIn: 'root'})
export class ItemService {
  constructor(private itemData: ItemData) {
  }

  async getItemByCode(itemCodeRequest: ItemCodeRequest): Promise<ItemModel | null> {
    const response = await this.itemData.getItemByCode(itemCodeRequest);
    if (!response.isSuccessful)
      return null;

    return response.itemModel;
  }

  async getItemByFilterList(itemFilterRequest: ItemFilterRequest): Promise<ItemModel[]> {
    const response = await this.itemData.getItemByFilterList(itemFilterRequest);
    if (!response.isSuccessful)
      return [];

    return response.itemModels;
  }

  async getItemRating(getItemRatingRequest: GetItemRatingRequest): Promise<RatingType | null> {
    const response = await this.itemData.getItemRating(getItemRatingRequest);
    if (!response.isSuccessful)
      return null;

    return response.type;
  }

  async setItemRating(setItemRatingRequest: SetItemRatingRequest): Promise<void> {
    await this.itemData.setItemRating(setItemRatingRequest);
  }
}
