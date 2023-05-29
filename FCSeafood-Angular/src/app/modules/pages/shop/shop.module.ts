import { NgModule } from '@angular/core';
import { NgForOf, NgIf } from '@angular/common';
import { RouterModule, Routes } from "@angular/router";
import { ShopComponent } from "@modules-pages/shop/shop.component";
import { ShopContentComponent } from './shop-content/shop-content.component';


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
  imports: [RouterModule.forChild(routes), NgForOf, NgIf],
  exports: [RouterModule]
})
export class ShopModule {
}
