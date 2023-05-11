import {Injectable} from "@angular/core";
import {Router} from "@angular/router";

@Injectable({providedIn: 'root'})
export class RouteHelper {
  paths: any;

  constructor(private router: Router) {
    this.paths = {
      home: "/home",
      shop: {
        category: "/shop/category",
        subcategory: "/shop/subcategory"
      }
    };
  }

  async goToHome() {
    await this.router.navigate([this.paths.shop]);
  }

  async goToCategory() {
    await this.router.navigate([this.paths.shop.category]);
  }

  async goToSubCategory() {
    await this.router.navigate([this.paths.shop.subcategory]);
  }
}
