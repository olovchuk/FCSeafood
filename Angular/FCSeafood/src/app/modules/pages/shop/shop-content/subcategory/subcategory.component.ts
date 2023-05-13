import {Component, OnInit} from '@angular/core';
import {CommonDataStateService} from "@common-services/common-data-state/common-data-state.service";
import {ActivatedRoute} from "@angular/router";
import {CategoryType, CategoryTypeValues} from "@common-enums/category.type";
import {SubcategoryTModel} from "@common-data/common/models/common/subcategory-type.model";

@Component({
  selector: 'shop-subcategory',
  templateUrl: './subcategory.component.html',
  styleUrls: ['./subcategory.component.scss']
})
export class SubcategoryComponent implements OnInit {
  title: string = '';
  subcategoryTListModel: SubcategoryTModel[] = [];

  constructor(private commonDataStateService: CommonDataStateService,
              private route: ActivatedRoute) {
  }

  async ngOnInit(): Promise<void> {
    let category = CategoryType.Unknown;

    this.route.params.subscribe(params => {
      let categoryTypeValue = CategoryTypeValues.find(category => category.value === params['categoryType'].toLowerCase());
      if (categoryTypeValue)
        category = categoryTypeValue?.id;
    });

    this.title = 'Choose subcategory'
    this.subcategoryTListModel = await this.commonDataStateService.getSubcategoryByCategoryListAsync(category);
    console.log(this.subcategoryTListModel)
  }
}
