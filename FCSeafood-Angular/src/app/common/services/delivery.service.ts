import { Injectable } from "@angular/core";
import { DeliveryData } from "@common-data/delivery/delivery.data";
import { InsertDeliveryRequest } from "@common-data/delivery/http/request/insert-delivery.request";
import { UserIdRequest } from "@common-data/user-information/http/request/user-id.request";
import { DeliveryModel } from "@common-models/delivery.model";

@Injectable({providedIn: 'root'})
export class DeliveryService {
  constructor(private deliveryData: DeliveryData) {
  }

  async insertDelivery(deliveryRequest: InsertDeliveryRequest): Promise<string | null> {
    const response = await this.deliveryData.insertDelivery(deliveryRequest);
    if (!response.isSuccessful)
      return null;

    return response.trackingNumber;
  }

  async getDeliveryList(userIdRequest: UserIdRequest): Promise<DeliveryModel[]> {
    const response = await this.deliveryData.getDeliveryList(userIdRequest);
    if (!response.isSuccessful)
      return [];

    return response.deliveryModels;
  }
}
