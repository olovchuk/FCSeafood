import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { ShopSiteMenuState } from "@common-states/shop-site-menu.state";
import { RouteHelper } from "@common-helpers/route.helper";
import { Subscription } from "rxjs";

@Injectable({providedIn: 'root'})
export class ShopSiteMenuStateService {
  isInit: boolean = false;

  urlSubscription!: Subscription;

  constructor(private shopSiteMenuState: ShopSiteMenuState,
              private routeHelper: RouteHelper,
              private router: Router) {
  }

  get state(): ShopSiteMenuState {
    return this.shopSiteMenuState;
  }

  async init(): Promise<void> {
    this.urlSubscription = this.router.events.subscribe(() => {
      this.updateMenu();
    });

    this.isInit = true;
  }

  destroy(): void {
    this.isInit = false;
    if (this.urlSubscription
    )
      this.urlSubscription.unsubscribe();
  }

  updateMenu() {
    let url = location.href.replace(window.location.origin, '');
    if (url.indexOf('/shop/') < 0)
      return;

    this.shopSiteMenuState.menuItems = [];
    this.shopSiteMenuState.menuItems.push({text: 'Home', href: this.routeHelper.paths.home});

    const subCategoryRegex = /^\/shop\/category\/[^\/]+\/?$/;
    if (subCategoryRegex.test(url)) {
      this.shopSiteMenuState.menuItems.push({text: 'Category', href: this.routeHelper.paths.shop.category});
      return;
    }
    if (this.routeHelper.paths.shop.items === url) {
      this.shopSiteMenuState.menuItems.push({text: 'Category', href: this.routeHelper.paths.shop.category});
      return;
    }
    const itemRegex = /^\/shop\/item\/[^\/]+\/?$/;
    if (itemRegex.test(url)) {
      this.shopSiteMenuState.menuItems.push({text: 'Category', href: this.routeHelper.paths.shop.category});
      this.shopSiteMenuState.menuItems.push({text: 'Products', href: this.routeHelper.paths.shop.items});
      return;
    }
  }
}
