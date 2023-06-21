import { Component, OnDestroy, OnInit } from '@angular/core';
import { RouteHelper } from "@common-helpers/route.helper";
import { ShopFiltersStateService } from "@common-services/shop-filters-state/shop-filters-state.service";
import { ShopSiteMenuStateService } from "@common-services/shop-site-menu-state/shop-site-menu-state.service";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit, OnDestroy {
  constructor(public routeHelper: RouteHelper,
              private shopFiltersStateService: ShopFiltersStateService,
              private shopSiteMenuStateService: ShopSiteMenuStateService) {
  }

  async ngOnInit(): Promise<void> {
    await this.shopFiltersStateService.init();
    await this.shopSiteMenuStateService.init();
  }

  async ngOnDestroy(): Promise<void> {
    await this.shopFiltersStateService.save();
    await this.shopSiteMenuStateService.destroy();
  }
}
