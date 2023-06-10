import { ItemModel } from "@common-models/item.model";

export class OrderEntityModel {
  id: string = ''; // Guid
  item: ItemModel = new ItemModel();
  quantityPerKg: number = 0.0;
  price: number = 0.0;
}
