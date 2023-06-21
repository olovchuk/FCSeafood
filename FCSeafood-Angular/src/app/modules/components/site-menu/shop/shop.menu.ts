import { Component } from '@angular/core';
import { ShopSiteMenuState } from "@common-states/shop-site-menu.state";

@Component({
  selector: 'shop-menu',
  templateUrl: './shop.menu.html',
  styleUrls: ['./shop.menu.scss']
})
export class ShopMenu {
  constructor(public shopSiteMenuState: ShopSiteMenuState) {
  }
}
