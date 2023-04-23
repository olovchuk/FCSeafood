import {Component, NgModule, OnInit} from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import {ProductTypeCardComponent} from "@modules/pages/home/product-type-card/product-type-card.component";
import {MaterialModule} from "@modules/material/material.module";
import {WhyUsCardComponent} from "@modules/pages/home/why-us-card/why-us-card.component";
import {CommonData} from "@common-data/common/common.data";
import {CategoryTypeModel} from "@common-data/common/models/common/category-type.model";
import {NgForOf} from "@angular/common";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  categoryList: CategoryTypeModel[] = [];

  constructor(private commonData: CommonData) {

  }

  async ngOnInit(): Promise<void> {
    let categoryTypeListResponse = await this.commonData.GetCategoryListAsync();
    if (categoryTypeListResponse.isSuccessful) {
      this.categoryList = categoryTypeListResponse.categoryTypeModels;
    }
  }
}


const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  }
];

@NgModule({
  declarations: [
    HomeComponent,
    ProductTypeCardComponent,
    WhyUsCardComponent
  ],
  imports: [RouterModule.forChild(routes), MaterialModule, NgForOf],
  exports: [RouterModule]
})
export class HomeModule {
}
