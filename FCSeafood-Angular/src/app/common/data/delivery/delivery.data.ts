import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { DeliveryDataSettings } from "@common-data/delivery/delivery.data.settings";
import { MessageHelper } from "@common-helpers/message.helper";
import { DeliveryRequest } from "@common-data/delivery/http/request/delivery.request";
import { DeliveryResponse } from "@common-data/delivery/http/response/delivery.response";

@Injectable({providedIn: 'root'})
export class DeliveryData {
  constructor(private http: HttpClient,
              private settings: DeliveryDataSettings,
              private messageHelper: MessageHelper) {
  }

  async insertDelivery(deliveryRequest: DeliveryRequest): Promise<DeliveryResponse | null> {
    let response = await firstValueFrom(this.http.post<DeliveryResponse>(this.settings.insertDeliveryEndpoint, deliveryRequest));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }
}
