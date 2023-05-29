import { Component } from '@angular/core';
import { RouteHelper } from "@common-helpers/route.helper";
import { ShopFiltersStateService } from "@common-services/shop-filters-state/shop-filters-state.service";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent {
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
