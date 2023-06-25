import { DeliveryStatusTModel } from "@common-models/delivery-status-type.model";

export class DeliveryStatusTListResponse {
  isSuccessful: boolean = false;
  message: string = '';
  deliveryStatusTListModel: DeliveryStatusTModel[] = [];
}
