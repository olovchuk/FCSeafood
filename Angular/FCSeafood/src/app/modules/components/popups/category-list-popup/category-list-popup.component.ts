import {Component} from '@angular/core';
import {CommonDataState} from "@common-states/common-data.state";
import {CategoryType} from "@common-enums/category.type";
import {RouteHelper} from "@common-helpers/route.helper";

@Component({
  selector: 'app-category-list-popup',
  templateUrl: './category-list-popup.component.html',
  styleUrls: ['./category-list-popup.component.scss']
})
export class CategoryListPopupComponent {
  constructor(public commonDataState: CommonDataState,
              public routeHelper: RouteHelper) {
  }

  filterSubcategory(category: CategoryType) {
    return this.commonDataState.bindCategoryListModel.filter(x => x.categoryTModel.type === category).map(x => x.subcategoryTModel);
  }
}
