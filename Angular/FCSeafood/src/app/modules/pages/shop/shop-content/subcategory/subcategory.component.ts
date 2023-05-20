import {Component, OnDestroy, OnInit} from '@angular/core';
import {CommonDataStateService} from "@common-services/common-data-state/common-data-state.service";
import {ActivatedRoute} from "@angular/router";
import {CategoryType, CategoryTypeValues} from "@common-enums/category.type";
import {SubcategoryTModel} from "@common-data/common/models/common/subcategory-type.model";
import {CommonDataState} from "@common-states/common-data.state";
import {Subscription} from "rxjs";

@Component({
  selector: 'shop-subcategory',
  templateUrl: './subcategory.component.html',
  styleUrls: ['./subcategory.component.scss']
})
export class SubcategoryComponent implements OnInit, OnDestroy {
  title: string = '';
  subcategoryTListModel: SubcategoryTModel[] = [];
  routeSubscription!: Subscription;

  constructor(private commonDataState: CommonDataState,
              private route: ActivatedRoute) {
  }

  async ngOnInit(): Promise<void> {
    new Promise((resolve, reject) => {
      this.routeSubscription = this.route.params.subscribe(async (params) => {
        let category = CategoryType.Unknown;

        this.route.params.subscribe(params => {
          let categoryTypeValue = CategoryTypeValues.find(category => category.value === params['categoryType'].toLowerCase());
          if (categoryTypeValue)
            category = categoryTypeValue?.id;
        });

        this.title = 'Choose subcategory'
        this.subcategoryTListModel = this.commonDataState.bindCategoryListModel.filter(x => x.categoryTModel.type === category).map(x => x.subcategoryTModel);

        resolve(null);
      });
    });
  }

  ngOnDestroy(): void {
    this.routeSubscription.unsubscribe();
  }
}
