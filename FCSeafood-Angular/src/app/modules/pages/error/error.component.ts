import { Component } from '@angular/core';
import { RouteHelper } from "@common-helpers/route.helper";

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.scss']
})
export class ErrorComponent {
  constructor(public routeHelper: RouteHelper) {
  }
}
