import { Component, OnInit } from '@angular/core';
import { CategoryTModel } from "@common-models/category-type.model";
import { CommonService } from "@common-services/common.service";
import { RouteHelper } from "@common-helpers/route.helper";

@Component({
  selector: 'home-category-section',
  templateUrl: './category.section.html',
  styleUrls: ['./category.section.scss', '../../home.component.scss']
})
export class CategorySection implements OnInit {
  categoryTListModel: CategoryTModel[] = [];

  constructor(private commonService: CommonService,
              public routeHelper: RouteHelper) {
  }

  async ngOnInit(): Promise<void> {
    this.categoryTListModel = await this.commonService.getCategoryTListAsync();
  }
}
