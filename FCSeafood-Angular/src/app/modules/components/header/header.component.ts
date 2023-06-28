import { Component, OnInit } from '@angular/core';
import { RouteHelper } from "@common-helpers/route.helper";
import { AuthService } from "@common-services/auth.service";
import { AuthStateService } from "@common-services/auth-state/auth-sate.service";
import { MatDialog } from "@angular/material/dialog";
import { SignInPopup } from "@modules-components/popups/sign-in/sign-in.popup";
import { MenuItem } from "primeng/api";
import { CommonService } from "@common-services/common.service";
import { CartPopup } from "@modules-components/popups/cart/cart.popup";
import { OrderStateService } from "@common-services/order-state/order-state.service";
import { ShopFiltersStateService } from "@common-services/shop-filters-state/shop-filters-state.service";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  menuItems: MenuItem[] = [];

  constructor(private dialog: MatDialog,
              public authStateService: AuthStateService,
              private authService: AuthService,
              public routeHelper: RouteHelper,
              private commonService: CommonService,
              public orderStateService: OrderStateService,
              private shopFiltersStateService: ShopFiltersStateService) {
  }

  async ngOnInit(): Promise<void> {
    await this.initMenu();
  }

  showCartPopup() {
    this.dialog.open(CartPopup, {
      panelClass: ['animate__animated', 'animate__slideInRight', 'custom-container', 'border-primary-left'],
      position: {right: '0%'},
      minHeight: '100vh',
      width: '550px',
      maxWidth: '100vw'
    });
  }

  async accountClick(): Promise<void> {
    if (!this.authStateService.IsAuthorized) {
      this.dialog.open(SignInPopup, {
        panelClass: ['animate__animated', 'animate__slideInRight', 'custom-container', 'border-primary-left'],
        position: {right: '0%'},
        minHeight: '100vh',
        width: '550px',
        maxWidth: '100vw'
      });
      return;
    }

    await this.routeHelper.goToPersonalInformation();
  }

  async signOut(): Promise<void> {
    this.authService.signOut();
  }

  async initMenu(): Promise<void> {
    const categoryTList = await this.commonService.getCategoryTList();

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

    this.menuItems = [
      {
        label: 'Home',
        command: async (): Promise<void> => {
          await this.routeHelper.goToHome();
        }
      },
      {
        label: 'Products',
        items: productsItems
      },
      {
        label: 'About us',
        command: async (): Promise<void> => {
          await this.routeHelper.goToAboutUs();
        }
      }
    ];
  }
}
