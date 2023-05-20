import {Component, OnInit} from '@angular/core';
import {CategoryType} from "@common-enums/category.type";
import {RouteHelper} from "@common-helpers/route.helper";
import {CommonDataStateService} from "@common-services/common-data-state/common-data-state.service";
import {BindCategoryModel} from "@common-data/common/models/common/BindCategoryModel";
import {CategoryTModel} from "@common-data/common/models/common/category-type.model";

@Component({
  selector: 'app-category-list-popup',
  templateUrl: './category-list-popup.component.html',
  styleUrls: ['./category-list-popup.component.scss']
})
export class CategoryListPopupComponent implements OnInit {
  categoryTListModel: CategoryTModel[] = []
  bindCategoryListModel: BindCategoryModel[] = []

  constructor(public commonDataStateService: CommonDataStateService,
              public routeHelper: RouteHelper) {
  }

  async ngOnInit(): Promise<void> {
    this.categoryTListModel = await this.commonDataStateService.getCategoryTListAsync();
    this.bindCategoryListModel = await this.commonDataStateService.getBindCategoryListAsync();
  }

  filterSubcategory(category: CategoryType) {
    return this.bindCategoryListModel.filter(x => x.categoryTModel.type === category).map(x => x.subcategoryTModel);
  }
}
