import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import { PrimengModule } from "@modules/primeng/primeng.module";
import { NgForOf } from "@angular/common";
import { HomeComponent } from "@modules-pages/home/home.component";
import { MainSection } from "@modules-pages/home/sections/main/main.section";
import { CategorySection } from './sections/category/category.section';
import { CategoryTypeCard } from "@modules-pages/home/sections/category/category-type-card/category-type.card";
import { FirstPurchaseSection } from './sections/first-purchase/first-purchase.section';
import { AboutUsSection } from './sections/about-us/about-us.section';
import { AboutUsCard } from './sections/about-us/about-us-card/about-us.card';
import { SuppliersSection } from './sections/suppliers/suppliers.section';
import { DescriptionSection } from './sections/description/description.section';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  }
];

@NgModule({
  declarations: [
    HomeComponent,
    MainSection,
    CategorySection,
    CategoryTypeCard,
    FirstPurchaseSection,
    AboutUsSection,
    AboutUsCard,
    SuppliersSection,
    DescriptionSection
  ],
  imports: [RouterModule.forChild(routes), PrimengModule, NgForOf],
  exports: [RouterModule]
})
export class HomeModule {
}
