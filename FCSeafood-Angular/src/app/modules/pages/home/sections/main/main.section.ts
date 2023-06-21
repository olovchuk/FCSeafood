import { Component } from '@angular/core';
import { RouteHelper } from "@common-helpers/route.helper";

@Component({
  selector: 'home-main-section',
  templateUrl: './main.section.html',
  styleUrls: ['./main.section.scss', '../../home.component.scss']
})
export class MainSection {
  constructor(public routeHelper: RouteHelper) {
  }
}
