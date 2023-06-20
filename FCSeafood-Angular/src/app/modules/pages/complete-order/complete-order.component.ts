import { Component, OnInit } from '@angular/core';
import { RouteHelper } from "@common-helpers/route.helper";

@Component({
  selector: 'app-complete-order',
  templateUrl: './complete-order.component.html',
  styleUrls: ['./complete-order.component.scss']
})
export class CompleteOrderComponent implements OnInit {
  trackingNumber!: string;

  constructor(public routeHelper: RouteHelper) {
  }

  ngOnInit(): void {
    this.trackingNumber = this.routeHelper.getQueryParameter(this.routeHelper.query.trackingNumber);
  }
}
