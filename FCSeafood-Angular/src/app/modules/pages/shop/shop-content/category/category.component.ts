import { Component, OnInit } from '@angular/core';
import { CategoryTModel } from "@common-models/category-type.model";
import { CommonService } from "@common-services/common.service";

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {
  title: string = '';
  categoryTListModel: CategoryTModel[] = [];

  constructor(private commonService: CommonService) {
  }

  async ngOnInit(): Promise<void> {
    this.title = 'Choose category'
    this.categoryTListModel = await this.commonService.getCategoryTListAsync();
  }
}
