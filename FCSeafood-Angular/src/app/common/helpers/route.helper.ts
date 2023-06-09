import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { CategoryType, CategoryTypeValues } from "@common-enums/category.type";
import { SubcategoryType } from "@common-enums/subcategory.type";
import { ShopFiltersStateService } from "@common-services/shop-filters-state/shop-filters-state.service";

@Injectable({providedIn: 'root'})
export class RouteHelper {
  paths: any;

  previousUrl: string = '';
  private currentUrl: string = '';

  separateSign: string = '/';

  constructor(private router: Router,
              private shopFiltersStateService: ShopFiltersStateService) {
    this.paths = {
      error: '/error',
      home: '/home',
      shop: {
        item: '/shop/item/',
        items: '/shop/items',
        category: '/shop/category'
      }
    };
  }

  private async redirect(url: string) {
    this.previousUrl = location.href;
    this.currentUrl = url;
    await this.router.navigate([this.currentUrl]);
  }

  getCurrentUrl() {
    if (!this.currentUrl)
      this.currentUrl = this.router.url;

    return this.currentUrl;
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

  async goToItems(subcategoryType: SubcategoryType) {
    await this.shopFiltersStateService.changeSubcategory(subcategoryType);
    await this.redirect(this.paths.shop.items);
  }

  async goToItem(code: string) {
    await this.redirect(this.paths.shop.item + code);
  }
}
