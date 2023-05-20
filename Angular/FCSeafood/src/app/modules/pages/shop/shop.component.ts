import {Component, OnDestroy, OnInit} from '@angular/core';
import {ShopFiltersStateService} from "@common-services/shop-filters-state/shop-filters-state.service";
import {RouteHelper} from "@common-helpers/route.helper";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit, OnDestroy {
  constructor(public routeHelper: RouteHelper,
              private shopFiltersStateService: ShopFiltersStateService) {
  }

  async ngOnInit(): Promise<void> {
    await this.shopFiltersStateService.init();
  }

  async ngOnDestroy(): Promise<void> {
    await this.shopFiltersStateService.save();
  }
}
