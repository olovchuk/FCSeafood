import { NgModule } from '@angular/core';
import { NgOptimizedImage } from '@angular/common';
import { ShopMenu } from "@modules-components/site-menu/shop/shop.menu";
import { RouterModule } from "@angular/router";
import { PrimengModule } from "@modules/primeng/primeng.module";
import { MaterialModule } from "@modules/material/material.module";
import { ReactiveFormsModule } from "@angular/forms";

@NgModule({
  declarations: [
    ShopMenu
  ],
  exports: [
    ShopMenu
  ],
  imports: [
    RouterModule,
    NgOptimizedImage,
    PrimengModule,
    MaterialModule,
    ReactiveFormsModule
  ]
})
export class SiteMenuModule {
}
