import { Injectable } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { CategoryType, CategoryTypeValues } from "@common-enums/category.type";
import { ShopFiltersStateService } from "@common-services/shop-filters-state/shop-filters-state.service";

@Injectable({providedIn: 'root'})
export class RouteHelper {
  paths: any;
  query: any;

  previousUrl: string = '';
  private currentUrl: string = '';

  separateSign: string = '/';

  constructor(private router: Router,
              private activatedRoute: ActivatedRoute,
              private shopFiltersStateService: ShopFiltersStateService) {
    this.paths = {
      error: '/error',
      home: '/home',
      shop: {
        item: '/shop/item/',
        items: '/shop/items',
        category: '/shop/category'
      },
      payment: '/payment',
      completeOrder: '/complete-order',
      account: {
        personalInformation: '/account/personal-information',
        purchases: '/account/purchases',
        delivery: '/account/delivery'
      }
    };

    this.query = {
      trackingNumber: 'tn'
    }
  }

  private async redirect(url: string, queryParams: {} = {}) {
    this.previousUrl = location.href;
    this.currentUrl = url;
    await this.router.navigate([this.currentUrl], {queryParams: queryParams});
  }

  getCurrentUrl() {
    if (!this.currentUrl)
      this.currentUrl = this.router.url;

    return this.currentUrl;
  }

  getQueryParameter(query: string): string {
    const param = this.activatedRoute.snapshot.queryParamMap.get(query);
    return param ? param : '';
  }

  async goToError() {
    await this.redirect(this.paths.error);
  }

  async goToHome() {
    await this.redirect(this.paths.home);
  }

  async goToShop() {
    await this.redirect(this.paths.shop.items);
  }

  async goToCategory() {
    await this.redirect(this.paths.shop.category);
  }

  async goToSubcategory(categoryType: CategoryType) {
    let categoryTypeValue = CategoryTypeValues.find(x => x.id === categoryType);
    if (!categoryTypeValue)
      return;

    await this.shopFiltersStateService.changeCategory(categoryType);
    await this.redirect(this.paths.shop.category + this.separateSign + categoryTypeValue.value);
  }

  async goToItems() {
    await this.redirect(this.paths.shop.items);
  }

  async goToItem(code: string) {
    await this.redirect(this.paths.shop.item + code);
  }

  async goToPayment() {
    await this.redirect(this.paths.payment);
  }

  async goToOrderComplete(trackingNumber: string) {
    let queryParams = {
      [this.query.trackingNumber]: trackingNumber
    }
    await this.redirect(this.paths.completeOrder, queryParams);
  }

  async goToPersonalInformation() {
    await this.redirect(this.paths.account.personalInformation);
  }

  async goToPurchases() {
    await this.redirect(this.paths.account.purchases);
  }

  async goToDelivery() {
    await this.redirect(this.paths.account.delivery);
  }
}
