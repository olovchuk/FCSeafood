import {Component, OnInit} from '@angular/core';
import {CommonData} from "@common-data/common/common.data";
import {CategoryTModel} from "@common-data/common/models/common/category-type.model";

@Component({
  selector: 'home-category-section',
  templateUrl: './category.section.component.html',
  styleUrls: ['./category.section.component.scss']
})
export class CategorySectionComponent implements OnInit {
  categoryTListModel: CategoryTModel[] = [];

  constructor(private commonData: CommonData) {
  }

  async ngOnInit(): Promise<void> {
    let categoryTypeListResponse = await this.commonData.GetCategoryListAsync();
    if (categoryTypeListResponse.isSuccessful) {
      this.categoryTListModel = categoryTypeListResponse.categoryTModels;
    }
  }
}
