import { OrderModel } from "@common-models/order.model";

export class OrderListResponse {
  isSuccessful: boolean = false;
  message: string = '';
  orderModels: OrderModel[] = [];
}
