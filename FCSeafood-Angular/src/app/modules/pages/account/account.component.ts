import { Component, OnInit } from '@angular/core';
import { RouteHelper } from "@common-helpers/route.helper";
import { MenuItem } from "primeng/api";
import { expand } from "rxjs";

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {
  selectedPage!: number;

  accountMenu: MenuItem[] = [];

  constructor(public routeHelper: RouteHelper) {
  }

  ngOnInit() {
    switch (this.routeHelper.getCurrentUrl()) {
      case this.routeHelper.paths.account.personalInformation:
        this.selectedPage = 1;
        break;
      case this.routeHelper.paths.account.purchases:
        this.selectedPage = 2;
        break;
      case this.routeHelper.paths.account.delivery:
        this.selectedPage = 3;
        break;
    }

    this.accountMenu = [
      {
        label: 'Menu',
        items: [
          {
            label: 'Personal Information',
            command: async (event) => {
              await this.routeHelper.goToPersonalInformation();
              this.selectedPage = 1;
            }
          },
          {
            label: 'Purchases',
            command: async () => {
              await this.routeHelper.goToPurchases();
              this.selectedPage = 2;
            }
          },
          {
            label: 'My Deliveries',
            command: async () => {
              await this.routeHelper.goToDelivery();
              this.selectedPage = 3;
            }
          }
        ]
      }
    ];
  }
}
