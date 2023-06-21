import { Injectable } from "@angular/core";
import { CartCardInformation } from "@modules-components/popups/cart/cart.card/cart.card.component";
import { OrderModel } from "@common-models/order.model";

@Injectable({providedIn: 'root'})
export class OrderState {
  order: OrderModel = new OrderModel();
  orderEntityCount: number = 0;
  orderEntityInformation: CartCardInformation[] = [];
}
