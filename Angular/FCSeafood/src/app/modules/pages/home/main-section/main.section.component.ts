import {Component} from '@angular/core';
import {RouteHelper} from "@common-helpers/route.helper";

@Component({
  selector: 'home-main-section',
  templateUrl: './main.section.component.html',
  styleUrls: ['./main.section.component.scss']
})
export class MainSectionComponent {
  constructor(public routeHelper: RouteHelper) {
  }
}
