import { Injectable } from "@angular/core";
import { DeliveryData } from "@common-data/delivery/delivery.data";
import { DeliveryRequest } from "@common-data/delivery/http/request/delivery.request";

@Injectable({providedIn: 'root'})
export class DeliveryService {
  constructor(private deliveryData: DeliveryData) {
  }

  async insertDelivery(deliveryRequest: DeliveryRequest): Promise<void> {
    await this.deliveryData.insertDelivery(deliveryRequest);
  }
}
