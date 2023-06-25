import { Component, Input } from '@angular/core';
import { DeliveryModel } from "@common-models/delivery.model";
import { UiHelper } from "@common-helpers/ui.helper";
import { DeliveryStatusTModel } from "@common-models/delivery-status-type.model";
import { DeliveryStatusType } from "@common-enums/delivery-status.type";
import { ClipboardService } from "ngx-clipboard";

@Component({
  selector: 'account-delivery-card',
  templateUrl: './delivery.card.html',
  styleUrls: ['./delivery.card.scss']
})
export class DeliveryCard {
  protected readonly UiHelper = UiHelper;
  protected readonly DeliveryStatusType = DeliveryStatusType;

  @Input('delivery') delivery: DeliveryModel = new DeliveryModel();
  @Input('deliveryStatusTList') deliveryStatusTList: DeliveryStatusTModel[] = [];

  constructor(public clipboardService: ClipboardService) {
  }
}
