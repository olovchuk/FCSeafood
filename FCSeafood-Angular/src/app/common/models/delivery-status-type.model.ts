import { DeliveryStatusType } from "@common-enums/delivery-status.type";

export class DeliveryStatusTModel {
  type: DeliveryStatusType = DeliveryStatusType.Unknown;
  name: string = '';
}
