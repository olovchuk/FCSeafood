import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { HttpClient, HttpParams } from "@angular/common/http";
import { DeliveryDataSettings } from "@common-data/delivery/delivery.data.settings";
import { MessageHelper } from "@common-helpers/message.helper";
import { InsertDeliveryRequest } from "@common-data/delivery/http/request/insert-delivery.request";
import { TrackingNumberResponse } from "@common-data/delivery/http/response/tracking-number.response";
import { UserIdRequest } from "@common-data/user-information/http/request/user-id.request";
import { ItemListResponse } from "@common-data/item/http/response/item-list.response";
import { DeliveryListResponse } from "@common-data/delivery/http/response/delivery-list.response";

@Injectable({providedIn: 'root'})
export class DeliveryData {
  constructor(private http: HttpClient,
              private settings: DeliveryDataSettings,
              private messageHelper: MessageHelper) {
  }

  async insertDelivery(deliveryRequest: InsertDeliveryRequest): Promise<TrackingNumberResponse> {
    let response = await firstValueFrom(this.http.post<TrackingNumberResponse>(this.settings.insertDeliveryEndpoint, deliveryRequest));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async getDeliveryList(userIdRequest: UserIdRequest): Promise<DeliveryListResponse> {
    let params = new HttpParams();
    params = params.append('UserId', userIdRequest.userId);

    const response = await firstValueFrom(this.http.get<DeliveryListResponse>(this.settings.getDeliveryListEndpoint, {params: params}))
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }
}
