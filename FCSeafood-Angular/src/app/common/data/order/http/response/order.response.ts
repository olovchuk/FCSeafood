import { OrderModel } from "@common-models/order.model";

export class OrderResponse {
  isSuccessful: boolean = false;
  message: string = '';
  order: OrderModel = new OrderModel();
}
