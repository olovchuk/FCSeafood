import { OrderEntityModel } from "@common-models/order-entity.model";

export class OrderEntityRequest {
  userId: string = ''; // Guid
  orderEntity: OrderEntityModel = new OrderEntityModel();
}
