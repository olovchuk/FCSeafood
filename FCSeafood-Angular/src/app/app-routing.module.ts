import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'error',
    loadChildren: () => import('./modules/pages/error/error.module').then(m => m.ErrorModule)
  },
  {
    path: 'home',
    loadChildren: () => import('./modules/pages/home/home.module').then(m => m.HomeModule)
  },
  {
    path: 'shop',
    loadChildren: () => import('./modules/pages/shop/shop.module').then(m => m.ShopModule),
  },
  {
    path: 'payment',
    loadChildren: () => import('./modules/pages/payment/payment.module').then(m => m.PaymentModule),
  },
  {
    path: 'complete-order',
    loadChildren: () => import('./modules/pages/complete-order/complete-order.module').then(m => m.CompleteOrderModule),
  },
  {
    path: 'account',
    loadChildren: () => import('./modules/pages/account/account.module').then(m => m.AccountModule),
  },
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: '**', redirectTo: 'error', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
