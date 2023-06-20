import { Injectable } from "@angular/core";
import { OrderState } from "@common-states/order.state";
import { OrderService } from "@common-services/order.service";
import { AuthStateService } from "@common-services/auth-state/auth-sate.service";
import { CartCardInformation } from "@modules-components/popups/cart/cart.card/cart.card.component";
import { OrderEntityModel } from "@common-models/order-entity.model";
import { MessageHelper } from "@common-helpers/message.helper";
import { OrderModel } from "@common-models/order.model";

@Injectable({providedIn: 'root'})
export class OrderStateService {
  isInit: boolean = false;

  constructor(private orderState: OrderState,
              private orderService: OrderService,
              private authStateService: AuthStateService,
              private messageHelper: MessageHelper) {
  }

  get state(): OrderState {
    return this.orderState;
  }

  async init(): Promise<void> {
    if (!this.authStateService.token.UserId) {
      this.isInit = false;
      this.orderState = new OrderState();
      return;
    }

    await this.updateInformation();

    this.isInit = true;
  }

  Refresh() {
    this.orderState.order = new OrderModel();
    this.orderState.orderEntityCount = 0;
    this.orderState.orderEntityInformation = [];
  }

  private async updateInformation(): Promise<void> {
    let order = await this.orderService.getOrderByUser({id: this.authStateService.token.UserId});
    if (!order) {
      this.isInit = false;
      this.orderState = new OrderState();
      return;
    }

    this.orderState.order = order;
    this.loadOrderEntities();
  }

  private loadOrderEntities() {
    this.orderState.orderEntityInformation = [];
    this.orderState.orderEntityCount = this.orderState.order.orders.length;
    for (let i = 0; i < this.orderState.orderEntityCount; i++) {
      let cartInformation: CartCardInformation = {
        orderEntityId: this.orderState.order.orders[i].id,
        imagePath: this.orderState.order.orders[i].item.imagePath,
        name: this.orderState.order.orders[i].item.name,
        quantityPerKg: this.orderState.order.orders[i].quantityPerKg,
        price: this.orderState.order.orders[i].price
      };

      this.orderState.orderEntityInformation.push(cartInformation);
    }
  }

  async insertOrderEntity(orderEntity: OrderEntityModel): Promise<void> {
    if (!this.authStateService.token.UserId)
      return;

    await this.orderService.insertOrderEntity({userId: this.authStateService.token.UserId, orderEntity: orderEntity});
    await this.updateInformation();
  }

  async removeOrderEntity(orderEntityId: string): Promise<void> {
    if (!orderEntityId)
      return;

    await this.orderService.removeOrderEntity({orderId: this.orderState.order.id, orderEntityId: orderEntityId});
    this.orderState.order.orders = this.orderState.order.orders.filter(x => x.id !== orderEntityId);
    await this.updateInformation();
  }
}
