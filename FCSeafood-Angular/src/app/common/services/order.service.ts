import { Injectable } from "@angular/core";
import { OrderData } from "@common-data/order/order.data";
import { OrderModel } from "@common-models/order.model";
import { OrderUserRequest } from "@common-data/order/http/request/order-user.request";
import { OrderEntityRequest } from "@common-data/order/http/request/order-entity.request";
import { UserItemIdsRequest } from "@common-data/order/http/request/user-item-ids.request";
import { OrderOrderEntityIdsRequest } from "@common-data/order/http/request/order-order-entity-ids.request";

@Injectable({providedIn: 'root'})
export class OrderService {
  constructor(private orderData: OrderData) {
  }

  async insertOrderEntity(orderEntityRequest: OrderEntityRequest): Promise<void> {
    await this.orderData.insertOrderEntity(orderEntityRequest);
  }

  async isExistsItemInOrder(userItemIdsRequest: UserItemIdsRequest): Promise<boolean> {
    const response = await this.orderData.isExistsItemInOrder(userItemIdsRequest);
    return response.isExists;
  }

  async getOrderByUser(orderIdRequest: OrderUserRequest): Promise<OrderModel | null> {
    const response = await this.orderData.getOrderByUser(orderIdRequest);
    if (!response.isSuccessful)
      return null;

    return response.order;
  }

  async getOrderCountByUser(orderIdRequest: OrderUserRequest): Promise<number> {
    const response = await this.orderData.getOrderCountByUser(orderIdRequest);
    if (!response.isSuccessful)
      return 0;

    return response.count;
  }

  async removeOrderEntity(orderOrderEntityIdsRequest: OrderOrderEntityIdsRequest): Promise<void> {
    await this.orderData.removeOrderEntity(orderOrderEntityIdsRequest);
  }
}
