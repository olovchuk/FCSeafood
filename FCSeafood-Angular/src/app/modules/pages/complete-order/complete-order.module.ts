import { NgModule } from '@angular/core';
import { NgForOf } from '@angular/common';
import { RouterModule, Routes } from "@angular/router";
import { PrimengModule } from "@modules/primeng/primeng.module";
import { CompleteOrderComponent } from "@modules-pages/complete-order/complete-order.component";

const routes: Routes = [
  {
    path: '',
    component: CompleteOrderComponent
  }
];

@NgModule({
  declarations: [CompleteOrderComponent],
  imports: [RouterModule.forChild(routes), PrimengModule, NgForOf],
  exports: [RouterModule]
})
export class CompleteOrderModule {
}
