import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { DeliveryDataSettings } from "@common-data/delivery/delivery.data.settings";
import { MessageHelper } from "@common-helpers/message.helper";
import { InsertDeliveryRequest } from "@common-data/delivery/http/request/insert-delivery.request";
import { TrackingNumberResponse } from "@common-data/delivery/http/response/tracking-number.response";

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
}
