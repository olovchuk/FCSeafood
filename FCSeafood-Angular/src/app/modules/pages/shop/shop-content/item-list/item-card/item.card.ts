import { Component, Input } from '@angular/core';
import { ItemModel } from "@common-models/item.model";
import { RouteHelper } from "@common-helpers/route.helper";

@Component({
  selector: 'shop-item-card',
  templateUrl: './item.card.html',
  styleUrls: ['./item.card.scss']
})
export class ItemCard {
  @Input('item') item!: ItemModel;

  constructor(public routeHelper: RouteHelper) {
  }

  addToCart() {

  }
}
