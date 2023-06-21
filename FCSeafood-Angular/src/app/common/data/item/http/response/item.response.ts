import { ItemModel } from "@common-models/item.model";

export class ItemResponse {
  isSuccessful: boolean = false;
  message: string = '';
  itemModel: ItemModel = new ItemModel();
}
