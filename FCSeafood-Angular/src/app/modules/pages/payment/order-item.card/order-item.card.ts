import { Component, EventEmitter, Input, Output } from '@angular/core';
import { UiHelper } from "@common-helpers/ui.helper";

@Component({
  selector: 'payment-order-item-card',
  templateUrl: './order-item.card.html',
  styleUrls: ['./order-item.card.scss']
})
export class OrderItemCard {
  protected readonly UiHelper = UiHelper;

  @Input('cardInformation') cardInformation!: OrderItemCardInformation;
  @Output('removeEntityEvent') removeEntityEvent = new EventEmitter<string>();
}

export class OrderItemCardInformation {
  orderEntityId: string = '';
  imagePath: string = '';
  name: string = '';
  quantityPerKg: number = 0.0;
  price: number = 0.0;
}
