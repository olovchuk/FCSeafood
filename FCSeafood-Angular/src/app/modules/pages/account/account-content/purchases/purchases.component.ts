import { Component, OnInit } from '@angular/core';
import { OrderService } from "@common-services/order.service";
import { AuthStateService } from "@common-services/auth-state/auth-sate.service";
import { RouteHelper } from "@common-helpers/route.helper";
import { OrderModel } from "@common-models/order.model";
import { DeliveryService } from "@common-services/delivery.service";

@Component({
  selector: 'account-purchases',
  templateUrl: './purchases.component.html',
  styleUrls: ['./purchases.component.scss']
})
export class PurchasesComponent implements OnInit {
  order!: OrderModel;

  constructor(private routeHelper: RouteHelper,
              private authStateService: AuthStateService,
              private deliveryService: DeliveryService,
              private orderService: OrderService) {
  }

  async ngOnInit(): Promise<void> {
    if (!this.authStateService.token.UserId) {
      await this.routeHelper.goToError();
      return;
    }

    let order = await this.orderService.getOrderByUser({userId: this.authStateService.token.UserId});
    if (order)
      this.order = order;
  }
}
