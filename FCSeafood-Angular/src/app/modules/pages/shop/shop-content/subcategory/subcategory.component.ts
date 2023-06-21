import { Component, OnDestroy, OnInit } from '@angular/core';
import { SubcategoryTModel } from "@common-models/subcategory-type.model";
import { Subscription } from "rxjs";
import { RouteHelper } from "@common-helpers/route.helper";
import { CommonService } from "@common-services/common.service";
import { CategoryTypeValues } from "@common-enums/category.type";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'shop-subcategory',
  templateUrl: './subcategory.component.html',
  styleUrls: ['./subcategory.component.scss']
})
export class SubcategoryComponent implements OnInit, OnDestroy {
  title: string = '';
  subcategoryTListModel: SubcategoryTModel[] = [];
  routeSubscription!: Subscription;

  constructor(private commonService: CommonService,
              public routeHelper: RouteHelper,
              private route: ActivatedRoute) {
  }

  async ngOnInit(): Promise<void> {
    new Promise((resolve) => {
      this.routeSubscription = this.route.params.subscribe(async (params) => {
        let categoryTypeValue = CategoryTypeValues.find(category => category.value === params['categoryType'].toLowerCase());
        if (!categoryTypeValue) {
          await this.routeHelper.goToError();
          return;
        }

        this.title = 'Choose subcategory'
        this.subcategoryTListModel = await this.commonService.getSubcategoryTList(categoryTypeValue!.id);

        resolve(null);
      });
    });
  }

  ngOnDestroy(): void {
    this.routeSubscription.unsubscribe();
  }
}
