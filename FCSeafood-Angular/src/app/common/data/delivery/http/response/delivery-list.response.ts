import { DeliveryModel } from "@common-models/delivery.model";

export class DeliveryListResponse {
  isSuccessful: boolean = false;
  message: string = '';
  deliveryModels: DeliveryModel[] = [];
}
