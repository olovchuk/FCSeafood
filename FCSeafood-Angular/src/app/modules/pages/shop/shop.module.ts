import { NgModule } from '@angular/core';
import { NgForOf, NgIf, NgOptimizedImage } from '@angular/common';
import { RouterModule, Routes } from "@angular/router";
import { ShopComponent } from "@modules-pages/shop/shop.component";
import { ShopContentComponent } from './shop-content/shop-content.component';
import { PrimengModule } from "@modules/primeng/primeng.module";


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
    ShopContentComponent
  ],
  imports: [RouterModule.forChild(routes), PrimengModule, NgForOf, NgIf, NgOptimizedImage],
  exports: [RouterModule]
})
export class ShopModule {
}
