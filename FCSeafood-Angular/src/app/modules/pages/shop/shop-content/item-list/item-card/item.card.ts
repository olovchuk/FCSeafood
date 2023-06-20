import { Component, Input } from '@angular/core';
import { ItemModel } from "@common-models/item.model";
import { RouteHelper } from "@common-helpers/route.helper";
import { OrderEntityModel } from "@common-models/order-entity.model";
import { UiHelper } from "@common-helpers/ui.helper";
import { OrderStateService } from "@common-services/order-state/order-state.service";

@Component({
  selector: 'shop-item-card',
  templateUrl: './item.card.html',
  styleUrls: ['./item.card.scss']
})
export class ItemCard {
  @Input('item') item!: ItemModel;

  constructor(public routeHelper: RouteHelper,
              private orderStateService: OrderStateService) {
  }

  async addToCart(): Promise<void> {
    if (!this.item)
      return;

    let orderEntity: OrderEntityModel = {
      id: UiHelper.GUID_EMPTY,
      item: this.item,
      quantityPerKg: 1,
      price: this.item.price
    };
    await this.orderStateService.insertOrderEntity(orderEntity);
  }
}
