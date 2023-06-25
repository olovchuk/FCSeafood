import { Component, OnInit } from '@angular/core';
import { RouteHelper } from "@common-helpers/route.helper";

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {
  selectedPage!: number;

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
  }
}
