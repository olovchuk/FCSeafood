import {Component, NgModule, OnInit} from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import {MaterialModule} from "@modules/material/material.module";
import {NgForOf} from "@angular/common";
import {MainSectionComponent} from "@modules/pages/home/main-section/main.section.component";
import {CategorySectionComponent} from "@modules/pages/home/category-section/category.section.component";
import {FirstPurchaseSectionComponent} from "@modules/pages/home/first-purchase-section/first-purchase.section.component";
import {AboutUsSectionComponent} from "@modules/pages/home/about-us-section/about-us.section.component";
import {OffersSectionComponent} from "@modules/pages/home/offers-section/offers.section.component";
import {SuppliersSectionComponent} from "@modules/pages/home/suppliers-section/suppliers.section.component";
import {DescriptionSectionComponent} from "@modules/pages/home/description-section/description.section.component";
import {CategoryTypeCardComponent} from "@modules/pages/home/category-section/category-type-card/category-type.card.component";
import {AboutUsCardComponent} from "@modules/pages/home/about-us-section/about-us-card/about-us.card.component";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  async ngOnInit(): Promise<void> {
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

    MainSectionComponent,
    CategorySectionComponent,
    FirstPurchaseSectionComponent,
    AboutUsSectionComponent,
    OffersSectionComponent,
    SuppliersSectionComponent,
    DescriptionSectionComponent,

    CategoryTypeCardComponent,
    AboutUsCardComponent
  ],
  imports: [RouterModule.forChild(routes), MaterialModule, NgForOf],
  exports: [RouterModule]
})
export class HomeModule {
}
