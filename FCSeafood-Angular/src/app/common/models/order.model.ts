import { OrderEntityModel } from "@common-models/order-entity.model";

export class OrderModel {
  id: string = ''; // Guid
  user: string = '';
  totalPrice: number = 0.0;
  createdDate: Date = new Date();
  orders: OrderEntityModel[] = [];
}
