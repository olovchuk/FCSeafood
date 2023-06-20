import { Component, EventEmitter, Input, Output } from '@angular/core';
import { UiHelper } from "@common-helpers/ui.helper";

@Component({
  selector: 'cart-card-popup',
  templateUrl: './cart.card.component.html',
  styleUrls: ['./cart.card.component.scss']
})
export class CartCardComponent {
  protected readonly UiHelper = UiHelper;

  @Input('cartInformation') cartInformation!: CartCardInformation;
  @Output('removeEntityEvent') removeEntityEvent = new EventEmitter<string>();
}

export class CartCardInformation {
  orderEntityId: string = '';
  imagePath: string = '';
  name: string = '';
  quantityPerKg: number = 0.0;
  price: number = 0.0;
}
