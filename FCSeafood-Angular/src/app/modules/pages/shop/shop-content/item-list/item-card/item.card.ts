import { Component, Input } from '@angular/core';
import { ItemModel } from "@common-models/item.model";
import { RouteHelper } from "@common-helpers/route.helper";
import { AuthStateService } from "@common-services/auth-state/auth-sate.service";
import { OrderService } from "@common-services/order.service";
import { OrderEntityModel } from "@common-models/order-entity.model";
import { UiHelper } from "@common-helpers/ui.helper";
import { MessageHelper } from "@common-helpers/message.helper";

@Component({
  selector: 'shop-item-card',
  templateUrl: './item.card.html',
  styleUrls: ['./item.card.scss']
})
export class ItemCard {
  @Input('item') item!: ItemModel;

  constructor(public routeHelper: RouteHelper,
              private orderService: OrderService,
              private authStateService: AuthStateService,
              private messageHelper: MessageHelper) {
  }

  async addToCart(): Promise<void> {
    if (!this.item && !this.authStateService.token.UserId)
      return;

    let isExistsItemInOrder = await this.orderService.isExistsItemInOrder({userId: this.authStateService.token.UserId, itemId: this.item.id});
    if (isExistsItemInOrder) {
      this.messageHelper.warning("This item already in cart");
      return;
    }

    let orderEntity: OrderEntityModel = {
      id: UiHelper.GUID_EMPTY,
      item: this.item,
      quantityPerKg: 0.0,
      price: 0.0
    };
    await this.orderService.insertOrderEntity({userId: this.authStateService.token.UserId, orderEntity: orderEntity});
  }
}
