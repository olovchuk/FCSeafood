import {Injectable} from "@angular/core";
import {Router} from "@angular/router";
import {CategoryType, CategoryTypeValues} from "@common-enums/category.type";

@Injectable({providedIn: 'root'})
export class RouteHelper {
  paths: any;

  previousUrl: string = '';
  currentUrl: string = '';

  separateSign: string = '/';

  constructor(private router: Router) {
    this.paths = {
      error: '/error',
      home: '/home',
      shop: {
        main: '/shop',
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

    await this.redirect(this.paths.shop.category + this.separateSign + categoryTypeValue.value);
  }

  async goToItems() {
    await this.redirect(this.paths.shop.items);
  }
}
