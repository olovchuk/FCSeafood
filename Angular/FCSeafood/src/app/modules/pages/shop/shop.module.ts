import {NgModule} from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import {ShopComponent} from "@modules/pages/shop/shop.component";
import {MaterialModule} from "@modules/material/material.module";
import {NgForOf, NgIf, NgOptimizedImage} from "@angular/common";
import {ShopContentComponent} from './shop-content/shop-content.component';
import {FullSizeFilterComponent} from './panels/full-size-filter/full-size-filter.component';

const routes: Routes = [
  {
    path: '',
    component: ShopComponent,
    loadChildren: () => import('./shop-content/shop-content.module').then(m => m.ShopContentModule)
  }
];

@NgModule({
  declarations: [
    ShopComponent,
    ShopContentComponent,
    FullSizeFilterComponent
  ],
  imports: [RouterModule.forChild(routes), MaterialModule, NgForOf, NgOptimizedImage, NgIf],
  exports: [RouterModule]
})
export class ShopModule {
}
