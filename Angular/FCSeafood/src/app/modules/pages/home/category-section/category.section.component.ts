import {Component, OnInit} from '@angular/core';
import {CategoryTModel} from "@common-data/common/models/common/category-type.model";
import {CommonDataStateService} from "@common-services/common-data-state/common-data-state.service";

@Component({
  selector: 'home-category-section',
  templateUrl: './category.section.component.html',
  styleUrls: ['./category.section.component.scss']
})
export class CategorySectionComponent implements OnInit {
  categoryTListModel: CategoryTModel[] = [];

  constructor(private commonDataStateService: CommonDataStateService) {
  }

  async ngOnInit(): Promise<void> {
    this.categoryTListModel = this.commonDataStateService.state.categoryTListModel;
  }
}
