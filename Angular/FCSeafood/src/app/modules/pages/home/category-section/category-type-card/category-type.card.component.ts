import {Component, Input} from '@angular/core';
import {CategoryTModel} from "@common-data/common/models/common/category-type.model";
import {RouteHelper} from "@common-helpers/route.helper";

@Component({
  selector: 'home-category-type-card',
  templateUrl: './category-type.card.component.html',
  styleUrls: ['./category-type.card.component.scss']
})
export class CategoryTypeCardComponent {
  @Input('categoryTModel') categoryTModel!: CategoryTModel;

  constructor(public routeHelper: RouteHelper) {
  }
}
