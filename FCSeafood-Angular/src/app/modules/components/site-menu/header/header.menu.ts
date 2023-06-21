import { Component, OnInit } from '@angular/core';
import { MenuItem } from "primeng/api";
import { CommonService } from "@common-services/common.service";
import { RouteHelper } from "@common-helpers/route.helper";
import { ShopFiltersStateService } from "@common-services/shop-filters-state/shop-filters-state.service";

@Component({
  selector: 'header-menu',
  templateUrl: './header.menu.html',
  styleUrls: ['./header.menu.scss']
})
export class HeaderMenu implements OnInit {
  menuItems: MenuItem[] = [];

  constructor(private routeHelper: RouteHelper,
              private commonService: CommonService,
              private shopFiltersStateService: ShopFiltersStateService) {
  }

  async ngOnInit(): Promise<void> {
    let categoryTList = await this.commonService.getCategoryTList();

    let productsItems: MenuItem[] = [];
    for (let i = 0; i < categoryTList.length; i++) {
      productsItems.push({
        label: categoryTList[i].name,
        items: []
      });

      for (let j = 0; j < categoryTList[i].subcategoryTModelList.length; j++) {
        productsItems[i].items?.push({
          label: categoryTList[i].subcategoryTModelList[j].name,
          command: async (): Promise<void> => {
            await this.shopFiltersStateService.changeCategory(categoryTList[i].type);
            await this.shopFiltersStateService.changeSubcategory(categoryTList[i].subcategoryTModelList[j].type);
            await this.shopFiltersStateService.applyFiltersSubscription$.emit();
            await this.routeHelper.goToItems();
          }
        })
      }
    }

    this.menuItems = [{
      label: 'Products',
      items: productsItems
    }];
  }
}
