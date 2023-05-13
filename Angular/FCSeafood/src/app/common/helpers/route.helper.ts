import {Injectable} from "@angular/core";
import {Router} from "@angular/router";
import {CategoryType, CategoryTypeValues} from "@common-enums/category.type";

@Injectable({providedIn: 'root'})
export class RouteHelper {
  paths: any;

  constructor(private router: Router) {
    this.paths = {
      home: '/home',
      shop: {
        main: '/shop',
        category: '/shop/category'
      }
    };
  }

  async goToHome() {
    await this.router.navigate([this.paths.home]);
  }

  async goToShop() {
    await this.router.navigate([this.paths.shop.main]);
  }

  async goToCategory() {
    await this.router.navigate([this.paths.shop.category]);
  }

  async goToSubcategory(categoryType: CategoryType) {
    let categoryTypeValue = CategoryTypeValues.find(x => x.id == categoryType);
    if (categoryTypeValue)
      await this.router.navigate([this.paths.shop.category + '/' + categoryTypeValue.value]);
  }
}
