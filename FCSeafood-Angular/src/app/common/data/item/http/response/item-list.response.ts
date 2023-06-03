import { ItemModel } from "@common-models/item.model";

export class ItemListResponse {
  isSuccessful: boolean = false;
  message: string = '';
  itemModels: ItemModel[] = [];
}
