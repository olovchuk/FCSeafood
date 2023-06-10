import { Injectable } from "@angular/core";
import { OrderData } from "@common-data/order/order.data";
import { OrderModel } from "@common-models/order.model";
import { OrderUserRequest } from "@common-data/order/http/request/order-user.request";

@Injectable({providedIn: 'root'})
export class OrderService {
  constructor(private orderData: OrderData) {
  }

  async getOrderByUser(orderIdRequest: OrderUserRequest): Promise<OrderModel | null> {
    const response = await this.orderData.getOrderByUser(orderIdRequest);
    if (!response.isSuccessful)
      return null;

    return response.order;
  }
}
