import { Component, Input } from '@angular/core';
import { OrderModel } from "@common-models/order.model";
import { UiHelper } from "@common-helpers/ui.helper";

@Component({
  selector: 'account-purchases-card',
  templateUrl: './purchases.card.html',
  styleUrls: ['./purchases.card.scss']
})
export class PurchasesCard {
  protected readonly UiHelper = UiHelper;

  @Input('order') order: OrderModel = new OrderModel();
}
