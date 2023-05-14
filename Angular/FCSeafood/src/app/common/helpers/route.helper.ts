import {Injectable} from "@angular/core";
import {Router} from "@angular/router";
import {CategoryType, CategoryTypeValues} from "@common-enums/category.type";

@Injectable({providedIn: 'root'})
export class RouteHelper {
  paths: any;

  previousUrl: string = '';
  currentUrl: string = '';

  constructor(private router: Router) {
    this.paths = {
      home: '/home',
      shop: {
        main: '/shop',
        category: '/shop/category'
      }
    };
  }

  private async redirect() {
    await this.router.navigate([this.currentUrl]);
  }

  async goToHome() {
    this.previousUrl = location.href;
    this.currentUrl = this.paths.home;
    await this.redirect();
  }

  async goToShop() {
    this.previousUrl = location.href;
    this.currentUrl = this.paths.shop.main;
    await this.redirect();
  }

  async goToCategory() {
    this.previousUrl = location.href;
    this.currentUrl = this.paths.shop.category;
    await this.redirect();
  }

  async goToSubcategory(categoryType: CategoryType) {
    let categoryTypeValue = CategoryTypeValues.find(x => x.id == categoryType);
    if (!categoryTypeValue)
      return;

    this.previousUrl = location.href;
    this.currentUrl = this.paths.shop.category + '/' + categoryTypeValue.value;
    await this.redirect();
  }
}
