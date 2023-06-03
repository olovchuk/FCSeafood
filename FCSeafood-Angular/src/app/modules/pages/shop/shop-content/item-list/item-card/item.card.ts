import { Component, Input } from '@angular/core';
import { ItemModel } from "@common-models/item.model";

@Component({
  selector: 'shop-item-card',
  templateUrl: './item.card.html',
  styleUrls: ['./item.card.scss']
})
export class ItemCard {
  @Input('itemModel') itemModel!: ItemModel;
}
