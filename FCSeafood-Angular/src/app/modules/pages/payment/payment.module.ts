import { NgModule } from '@angular/core';
import { NgForOf, NgIf, NgOptimizedImage } from '@angular/common';
import { PaymentComponent } from "@modules-pages/payment/payment.component";
import { RouterModule, Routes } from "@angular/router";
import { PrimengModule } from "@modules/primeng/primeng.module";
import { ReactiveFormsModule } from "@angular/forms";
import { OrderItemCard } from './order-item.card/order-item.card';

const routes: Routes = [
  {
    path: '',
    component: PaymentComponent
  }
];

@NgModule({
  declarations: [
    PaymentComponent,
    OrderItemCard
  ],
  imports: [RouterModule.forChild(routes), PrimengModule, NgForOf, NgIf, NgOptimizedImage, ReactiveFormsModule],
  exports: [RouterModule]
})
export class PaymentModule {
}
