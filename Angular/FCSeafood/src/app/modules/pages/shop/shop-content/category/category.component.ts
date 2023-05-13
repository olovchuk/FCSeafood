import {Component, OnInit} from '@angular/core';
import {CommonDataStateService} from "@common-services/common-data-state/common-data-state.service";
import {CategoryTModel} from "@common-data/common/models/common/category-type.model";

@Component({
  selector: 'shop-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {
  title: string = '';
  categoryTListModel: CategoryTModel[] = [];

  constructor(private commonDataStateService: CommonDataStateService) {
  }

  async ngOnInit(): Promise<void> {
    this.title = 'Choose category'
    this.categoryTListModel = this.commonDataStateService.state.categoryTListModel;
  }
}
