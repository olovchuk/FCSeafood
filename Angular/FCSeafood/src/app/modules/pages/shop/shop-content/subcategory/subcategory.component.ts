import {Component, OnInit} from '@angular/core';
import {CommonDataStateService} from "@common-services/common-data-state/common-data-state.service";
import {SubcategoryTModel} from "@common-data/common/models/common/subcategory-type.model";
import {RouteHelper} from "@common-helpers/route.helper";
import {CategoryTypeValues} from "@common-enums/category.type";

@Component({
  selector: 'shop-subcategory',
  templateUrl: './subcategory.component.html',
  styleUrls: ['./subcategory.component.scss']
})
export class SubcategoryComponent implements OnInit {
  title: string = '';
  subcategoryTListModel: SubcategoryTModel[] = [];

  constructor(private commonDataStateService: CommonDataStateService,
              public routeHelper: RouteHelper) {
  }

  async ngOnInit(): Promise<void> {
    this.title = 'Choose subcategory'
    let categoryQueryParam = this.routeHelper.getCurrentUrl().split('/').pop();
    let categoryTypeValue = CategoryTypeValues.find(x => x.value === categoryQueryParam);
    if (!categoryTypeValue)
      await this.routeHelper.goToError();

    this.subcategoryTListModel = await this.commonDataStateService.getSubcategoryTListAsync(categoryTypeValue!.id);
  }
}
