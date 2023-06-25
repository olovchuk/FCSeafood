import { Component, OnInit } from '@angular/core';
import { RouteHelper } from "@common-helpers/route.helper";
import { AuthStateService } from "@common-services/auth-state/auth-sate.service";
import { DeliveryService } from "@common-services/delivery.service";
import { DeliveryModel } from "@common-models/delivery.model";
import { CommonService } from "@common-services/common.service";
import { DeliveryStatusTModel } from "@common-models/delivery-status-type.model";

@Component({
  selector: 'account-delivery',
  templateUrl: './delivery.component.html',
  styleUrls: ['./delivery.component.scss']
})
export class DeliveryComponent implements OnInit {
  deliveries: DeliveryModel[] = [];
  deliveryStatusTList: DeliveryStatusTModel[] = []

  constructor(private routeHelper: RouteHelper,
              private authStateService: AuthStateService,
              private deliveryService: DeliveryService,
              private commonService: CommonService) {
  }

  async ngOnInit(): Promise<void> {
    if (!this.authStateService.token.UserId) {
      await this.routeHelper.goToError();
      return;
    }

    this.deliveries = await this.deliveryService.getDeliveryList({userId: this.authStateService.token.UserId});
    this.deliveryStatusTList = await this.commonService.getDeliveryStatusTList()
  }
}
