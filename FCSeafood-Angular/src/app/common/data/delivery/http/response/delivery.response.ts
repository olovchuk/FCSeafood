import { DeliveryModel } from "@common-models/delivery.model";

export class DeliveryResponse {
  isSuccessful: boolean = false;
  message: string = '';
  deliveryModel: DeliveryModel = new DeliveryModel();
}
