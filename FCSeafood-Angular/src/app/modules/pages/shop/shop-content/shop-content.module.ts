import { NgModule } from '@angular/core';
import { NgForOf, NgOptimizedImage } from '@angular/common';
import { RouterModule, Routes } from "@angular/router";
import { PrimengModule } from "@modules/primeng/primeng.module";
import { CategoryComponent } from "@modules-pages/shop/shop-content/category/category.component";
import { CategoryTypeCard } from './category/category-type-card/category-type.card';
import { SubcategoryComponent } from './subcategory/subcategory.component';
import { SubcategoryTypeCard } from "@modules-pages/shop/shop-content/subcategory/subcategory-type-card/subcategory-type.card";
import { ItemListComponent } from './item-list/item-list.component';
import { ItemCard } from './item-list/item-card/item.card';
import { FilterComponent } from "@modules-pages/shop/panels/filter/filter.component";

const routes: Routes = [
  {path: '', redirectTo: 'items', pathMatch: 'full'},
  {path: 'items', component: ItemListComponent},
  {path: 'category', component: CategoryComponent},
  {path: 'category/:categoryType', component: SubcategoryComponent},
];

@NgModule({
  declarations: [
    CategoryComponent,
    CategoryTypeCard,
    SubcategoryComponent,
    SubcategoryTypeCard,
    ItemListComponent,
    ItemCard,
    FilterComponent
  ],
  imports: [RouterModule.forChild(routes), PrimengModule, NgForOf, NgOptimizedImage],
  exports: [RouterModule]
})
export class ShopContentModule {
}
