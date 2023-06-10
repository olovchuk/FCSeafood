import { Component, OnInit } from '@angular/core';
import { DialogRef } from "@angular/cdk/dialog";
import { RouteHelper } from "@common-helpers/route.helper";
import { AuthStateService } from "@common-services/auth-state/auth-sate.service";
import { OrderService } from "@common-services/order.service";
import { OrderModel } from "@common-models/order.model";
import { CartCardInformation } from "@modules-components/popups/cart/cart.card/cart.card.component";
import { UserInformationStateService } from "@common-services/user-information-state/user-information-state";
import { UiHelper } from "@common-helpers/ui.helper";
import { ShopFiltersStateService } from "@common-services/shop-filters-state/shop-filters-state.service";

@Component({
  selector: 'app-cart',
  templateUrl: './cart.popup.html',
  styleUrls: ['./cart.popup.scss']
})
export class CartPopup implements OnInit {
  protected readonly UiHelper = UiHelper;

  order: OrderModel = new OrderModel();
  cartInformationList: CartCardInformation[] = [];

  constructor(private dialogRef: DialogRef<CartPopup>,
              public routeHelper: RouteHelper,
              private authStateService: AuthStateService,
              private userInformationStateService: UserInformationStateService,
              private shopFiltersStateService: ShopFiltersStateService,
              private orderService: OrderService) {
  }

  async ngOnInit(): Promise<void> {
    if (this.authStateService.IsAuthorized && this.authStateService.token.UserId) {
      let order = await this.orderService.getOrderByUser({id: this.authStateService.token.UserId});
      if (!order) {
        return;
      }

      this.order = order;

      if (this.order.orders.length > 0) {
        for (let i = 0; i < this.order.orders.length; i++) {
          let cartInformation: CartCardInformation = {
            imagePath: this.order.orders[i].item.imagePath,
            name: this.order.orders[i].item.name,
            quantityPerKg: this.order.orders[i].quantityPerKg,
            price: this.order.orders[i].price
          };

          this.cartInformationList.push(cartInformation);
        }
      }
    }
    else {

    }
  }

  async continueShopping(): Promise<void> {
    await this.shopFiltersStateService.refresh();
    await this.routeHelper.goToShop();
    this.dialogRef.close();
  }
}
