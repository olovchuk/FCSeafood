import { Component, Input } from '@angular/core';
import { CategoryTModel } from "@common-models/category-type.model";
import { RouteHelper } from "@common-helpers/route.helper";

@Component({
  selector: 'home-category-type-card',
  templateUrl: './category-type.card.html',
  styleUrls: ['./category-type.card.scss']
})
export class CategoryTypeCard {
  @Input('categoryTModel') categoryTModel!: CategoryTModel;

  constructor(public routeHelper: RouteHelper) {
  }
}
