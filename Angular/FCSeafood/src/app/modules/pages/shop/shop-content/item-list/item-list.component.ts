import {Component, OnDestroy, OnInit} from '@angular/core';
import {CategoryType, CategoryTypeValues} from "@common-enums/category.type";
import {SubcategoryTModel} from "@common-data/common/models/common/subcategory-type.model";
import {Subscription} from "rxjs";
import {CommonDataState} from "@common-states/common-data.state";
import {ActivatedRoute} from "@angular/router";
import {SubcategoryType, SubcategoryTypeValues} from "@common-enums/sub-category.type";

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.scss']
})
export class ItemListComponent implements OnInit, OnDestroy {
  title: string = '';
  subcategoryTListModel: SubcategoryTModel[] = [];
  routeSubscription!: Subscription;

  constructor(private commonDataState: CommonDataState,
              private route: ActivatedRoute) {
  }


  async ngOnInit(): Promise<void> {
    new Promise((resolve, reject) => {
      this.routeSubscription = this.route.params.subscribe(async (params) => {
        let subcategory = SubcategoryType.Unknown;

        this.route.params.subscribe(params => {
          let subcategoryTypeValue = SubcategoryTypeValues.find(subcategory => subcategory.value === params['subcategoryType'].toLowerCase());
          if (subcategoryTypeValue)
            subcategory = subcategoryTypeValue?.id;
        });

        this.title = subcategory.toString();

        resolve(null);
      });
    });
  }

  ngOnDestroy(): void {
    this.routeSubscription.unsubscribe();
  }
}
