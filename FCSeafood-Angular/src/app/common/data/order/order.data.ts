import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { HttpClient, HttpParams } from "@angular/common/http";
import { MessageHelper } from "@common-helpers/message.helper";
import { OrderDataSettings } from "@common-data/order/order.data.settings";
import { OrderResponse } from "@common-data/order/http/response/order.response";
import { OrderUserRequest } from "@common-data/order/http/request/order-user.request";

@Injectable({providedIn: 'root'})
export class OrderData {
  constructor(private http: HttpClient,
              private settings: OrderDataSettings,
              private messageHelper: MessageHelper) {
  }

  async getOrderByUser(orderIdRequest: OrderUserRequest): Promise<OrderResponse> {
    let params = new HttpParams();
    params = params.append('UserId', orderIdRequest.id);

    const response = await firstValueFrom(this.http.get<OrderResponse>(this.settings.getOrderByUser, {params: params}))
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }
}
