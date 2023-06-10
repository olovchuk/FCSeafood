import { Component, Input } from '@angular/core';
import { UiHelper } from "@common-helpers/ui.helper";

@Component({
  selector: 'cart-card',
  templateUrl: './cart.card.component.html',
  styleUrls: ['./cart.card.component.scss']
})
export class CartCardComponent {
  protected readonly UiHelper = UiHelper;

  @Input('cartInformation') cartInformation!: CartCardInformation;
}

export class CartCardInformation {
  imagePath: string = '';
  name: string = '';
  quantityPerKg: number = 0.0;
  price: number = 0.0;
}
