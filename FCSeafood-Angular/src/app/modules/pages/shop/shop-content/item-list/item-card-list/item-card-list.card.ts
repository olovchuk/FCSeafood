import { Component, Input } from '@angular/core';
import { UiHelper } from "@common-helpers/ui.helper";
import { ItemModel } from "@common-models/item.model";
import { RouteHelper } from "@common-helpers/route.helper";
import { OrderStateService } from "@common-services/order-state/order-state.service";
import { OrderEntityModel } from "@common-models/order-entity.model";

@Component({
  selector: 'shop-item-card-list',
  templateUrl: './item-card-list.card.html',
  styleUrls: ['./item-card-list.card.scss']
})
export class ItemCardListCard {
  protected readonly UiHelper = UiHelper;

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
