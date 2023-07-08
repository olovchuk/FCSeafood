import { Injectable } from "@angular/core";
import { OrderData } from "@common-data/order/order.data";
import { OrderModel } from "@common-models/order.model";
import { OrderEntityRequest } from "@common-data/order/http/request/order-entity.request";
import { OrderOrderEntityIdsRequest } from "@common-data/order/http/request/order-order-entity-ids.request";
import { UserIdRequest } from "@common-data/user-information/http/request/user-id.request";

@Injectable({providedIn: 'root'})
export class OrderService {
  constructor(private orderData: OrderData) {
  }

  async insertOrderEntity(orderEntityRequest: OrderEntityRequest): Promise<void> {
    await this.orderData.insertOrderEntity(orderEntityRequest);
  }

  async getOrderByUser(userIdRequest: UserIdRequest): Promise<OrderModel | null> {
    const response = await this.orderData.getOrderByUser(userIdRequest);
    if (!response.isSuccessful)
      return null;

    return response.order;
  }

  async getCompleteOrderList(userIdRequest: UserIdRequest): Promise<OrderModel[]> {
    const response = await this.orderData.getCompleteOrderList(userIdRequest);
    if (!response.isSuccessful)
      return [];

    return response.orderModels;
  }

  async getOrderCountByUser(userIdRequest: UserIdRequest): Promise<number> {
    const response = await this.orderData.getOrderCountByUser(userIdRequest);
    if (!response.isSuccessful)
      return 0;

    return response.count;
  }

  async removeOrderEntity(orderOrderEntityIdsRequest: OrderOrderEntityIdsRequest): Promise<void> {
    await this.orderData.removeOrderEntity(orderOrderEntityIdsRequest);
  }
}
