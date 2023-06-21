import { OrderModel } from "@common-models/order.model";

export class OrderRequest {
  order: OrderModel = new OrderModel();
}
