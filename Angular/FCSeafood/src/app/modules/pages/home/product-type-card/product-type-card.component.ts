import {Component, Input} from '@angular/core';
import {CategoryTModel} from "@common-data/common/models/common/category-type.model";

@Component({
  selector: 'app-product-type-card',
  templateUrl: './product-type-card.component.html',
  styleUrls: ['./product-type-card.component.scss']
})
export class ProductTypeCardComponent {
  @Input('categoryTModel') categoryTModel!: CategoryTModel;
}
