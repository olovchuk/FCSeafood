import { Component, Input } from '@angular/core';
import { DeliveryModel } from "@common-models/delivery.model";
import { DeliveryStatusType } from "@common-enums/delivery-status.type";

@Component({
  selector: 'app-delivey-full-information',
  templateUrl: './delivery-full-information.popup.html',
  styleUrls: ['./delivery-full-information.popup.scss']
})
export class DeliveryFullInformationPopup {
  protected readonly DeliveryStatusType = DeliveryStatusType;

  @Input('delivery') delivery: DeliveryModel = new DeliveryModel();
}
