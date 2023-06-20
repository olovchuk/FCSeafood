import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { HttpClient, HttpParams } from "@angular/common/http";
import { MessageHelper } from "@common-helpers/message.helper";
import { OrderDataSettings } from "@common-data/order/order.data.settings";
import { OrderResponse } from "@common-data/order/http/response/order.response";
import { OrderUserRequest } from "@common-data/order/http/request/order-user.request";
import { OrderSimpleResponse } from "@common-data/order/http/response/order-simple.response";
import { OrderEntityRequest } from "@common-data/order/http/request/order-entity.request";
import { ExistsResponse } from "@common-data/order/http/response/exists.response";
import { UserItemIdsRequest } from "@common-data/order/http/request/user-item-ids.request";
import { OrderOrderEntityIdsRequest } from "@common-data/order/http/request/order-order-entity-ids.request";
import { CountResponse } from "@common-data/order/http/response/count.response";

@Injectable({providedIn: 'root'})
export class OrderData {
  constructor(private http: HttpClient,
              private settings: OrderDataSettings,
              private messageHelper: MessageHelper) {
  }

  async insertOrderEntity(orderEntityRequest: OrderEntityRequest): Promise<OrderSimpleResponse | null> {
    let response = await firstValueFrom(this.http.post<OrderSimpleResponse>(this.settings.insertOrderEntityEndpoint, orderEntityRequest));
    if (response.isSuccessful)
      this.messageHelper.success("Item successfully inserted!");
    else
      this.messageHelper.error(response.message);

    return response;
  }

  async getOrderByUser(orderUserRequest: OrderUserRequest): Promise<OrderResponse> {
    let params = new HttpParams();
    params = params.append('UserId', orderUserRequest.id);

    return await firstValueFrom(this.http.get<OrderResponse>(this.settings.getOrderByUserEndpoint, {params: params}));
  }

  async getOrderCountByUser(orderUserRequest: OrderUserRequest): Promise<CountResponse> {
    let params = new HttpParams();
    params = params.append('UserId', orderUserRequest.id);

    const response = await firstValueFrom(this.http.get<CountResponse>(this.settings.getOrderCountByUserEndpoint, {params: params}));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async removeOrderEntity(orderOrderEntityIdsRequest: OrderOrderEntityIdsRequest): Promise<void> {
    await firstValueFrom(this.http.post<ExistsResponse>(this.settings.removeOrderEntityEndpoint, orderOrderEntityIdsRequest));
  }
}
