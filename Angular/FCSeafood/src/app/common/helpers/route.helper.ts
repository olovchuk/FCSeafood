import {Injectable} from "@angular/core";
import {Router} from "@angular/router";
import {CategoryType, CategoryTypeValues} from "@common-enums/category.type";
import {SubcategoryType, SubcategoryTypeValues} from "@common-enums/sub-category.type";

@Injectable({providedIn: 'root'})
export class RouteHelper {
  paths: any;

  previousUrl: string = '';
  currentUrl: string = '';

  separateSign: string = '/';

  constructor(private router: Router) {
    this.paths = {
      home: '/home',
      shop: {
        main: '/shop',
        category: '/shop/category'
      }
    };
  }

  private async redirect(url: string) {
    this.previousUrl = location.href;
    this.currentUrl = url;
    await this.router.navigate([this.currentUrl]);
  }

  async goToHome() {
    await this.redirect(this.paths.home);
  }

  async goToShop() {
    await this.redirect(this.paths.shop.main);
  }

  async goToCategory() {
    await this.redirect(this.paths.shop.category);
  }

  async goToSubcategory(categoryType: CategoryType) {
    let categoryTypeValue = CategoryTypeValues.find(x => x.id === categoryType);
    if (!categoryTypeValue)
      return;

    await this.redirect(this.paths.shop.main + this.separateSign + categoryTypeValue.value);
  }

  async goToItems(subcategoryType: SubcategoryType) {
    const splitUrl = this.router.url.trim().split(this.separateSign).slice(1);
    if (splitUrl[0] !== 'shop') return;

    let categoryTypeValue = splitUrl[1];

    let subcategoryTypeValue = SubcategoryTypeValues.find(x => x.id === subcategoryType);
    if (!subcategoryTypeValue)
      return;

    await this.redirect(this.paths.shop.main + this.separateSign + categoryTypeValue + this.separateSign + subcategoryTypeValue.value);
  }
}
