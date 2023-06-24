import { NgModule } from '@angular/core';
import { NgForOf, NgIf, NgOptimizedImage } from '@angular/common';
import { RouterModule, Routes } from "@angular/router";
import { ShopComponent } from "@modules-pages/shop/shop.component";
import { ShopContentComponent } from './shop-content/shop-content.component';
import { PrimengModule } from "@modules/primeng/primeng.module";
import { SiteMenuModule } from "@modules-components/site-menu/site-menu.module";


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
    ShopContentComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    PrimengModule,
    NgForOf,
    NgIf,
    NgOptimizedImage,
    SiteMenuModule
  ],
  exports: [RouterModule]
})
export class ShopModule {
}
