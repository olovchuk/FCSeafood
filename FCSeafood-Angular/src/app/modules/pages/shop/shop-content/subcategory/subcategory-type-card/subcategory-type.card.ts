import { Component, Input } from '@angular/core';
import { SubcategoryTModel } from "@common-models/subcategory-type.model";
import { RouteHelper } from "@common-helpers/route.helper";

@Component({
  selector: 'shop-subcategory-type-card',
  templateUrl: './subcategory-type.card.html',
  styleUrls: ['./subcategory-type.card.scss']
})
export class SubcategoryTypeCard {
  @Input('subcategoryTModel') subcategoryTModel!: SubcategoryTModel;

  constructor(public routeHelper: RouteHelper) {
  }
}
