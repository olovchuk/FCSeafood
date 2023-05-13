import {Component, Input} from '@angular/core';
import {SubcategoryTModel} from "@common-data/common/models/common/subcategory-type.model";

@Component({
  selector: 'shop-subcategory-type-card',
  templateUrl: './subcategory-type-card.component.html',
  styleUrls: ['./subcategory-type-card.component.scss']
})
export class SubcategoryTypeCardComponent {
  @Input('subcategoryTModel') subcategoryTModel!: SubcategoryTModel;
}
