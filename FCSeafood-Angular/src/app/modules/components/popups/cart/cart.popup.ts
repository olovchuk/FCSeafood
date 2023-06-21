import { Component, OnInit } from '@angular/core';
import { RouteHelper } from "@common-helpers/route.helper";
import { AuthStateService } from "@common-services/auth-state/auth-sate.service";
import { UserInformationStateService } from "@common-services/user-information-state/user-information-state";
import { UiHelper } from "@common-helpers/ui.helper";
import { ShopFiltersStateService } from "@common-services/shop-filters-state/shop-filters-state.service";
import { OrderStateService } from "@common-services/order-state/order-state.service";

@Component({
  selector: 'app-cart',
  templateUrl: './cart.popup.html',
  styleUrls: ['./cart.popup.scss']
})
export class CartPopup implements OnInit {
  protected readonly UiHelper = UiHelper;

  constructor(public routeHelper: RouteHelper,
              private authStateService: AuthStateService,
              private userInformationStateService: UserInformationStateService,
              private shopFiltersStateService: ShopFiltersStateService,
              public orderStateService: OrderStateService) {
  }

  async ngOnInit(): Promise<void> {
    if (!this.orderStateService.isInit)
      await this.orderStateService.init();
  }

  async continueShopping(): Promise<void> {
    await this.shopFiltersStateService.refresh();
    await this.routeHelper.goToShop();
  }
}
