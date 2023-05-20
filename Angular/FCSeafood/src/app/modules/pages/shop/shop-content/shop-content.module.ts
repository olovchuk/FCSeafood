import {NgModule} from '@angular/core';
import {NgForOf, NgOptimizedImage} from '@angular/common';
import {CategoryComponent} from "@modules/pages/shop/shop-content/category/category.component";
import {SubcategoryComponent} from "@modules/pages/shop/shop-content/subcategory/subcategory.component";
import {RouterModule, Routes} from "@angular/router";
import {MaterialModule} from "@modules/material/material.module";
import {CategoryTypeCardShopComponent} from './category/category-type-card/category-type-card.component';
import {SubcategoryTypeCardComponent} from './subcategory/subcategory-type-card/subcategory-type-card.component';
import {ItemListComponent} from './item-list/item-list.component';

const routes: Routes = [
  {path: '', redirectTo: 'items', pathMatch: 'full'},
  {path: 'items', component: ItemListComponent},
  {path: 'category', component: CategoryComponent},
  {path: 'category/:categoryType', component: SubcategoryComponent},
];

@NgModule({
  declarations: [
    CategoryComponent,
    CategoryTypeCardShopComponent,
    SubcategoryComponent,
    SubcategoryTypeCardComponent,
    ItemListComponent
  ],
  imports: [RouterModule.forChild(routes), MaterialModule, NgForOf, NgOptimizedImage],
  exports: [RouterModule]
})
export class ShopContentModule {
}
