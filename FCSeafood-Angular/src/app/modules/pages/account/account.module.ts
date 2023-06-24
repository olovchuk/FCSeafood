import { NgModule } from '@angular/core';
import { NgForOf, NgIf, NgOptimizedImage } from '@angular/common';
import { AccountComponent } from "@modules-pages/account/account.component";
import { RouterModule, Routes } from "@angular/router";
import { AccountContentComponent } from './account-content/account-content.component';
import { PrimengModule } from "@modules/primeng/primeng.module";

const routes: Routes = [
  {
    path: '',
    component: AccountComponent,
    loadChildren: () => import('./account-content/account-content.module').then(m => m.AccountContentModule)
  }
];

@NgModule({
  declarations: [
    AccountComponent,
    AccountContentComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    PrimengModule,
    NgForOf,
    NgIf,
    NgOptimizedImage
  ],
  exports: [RouterModule]
})
export class AccountModule {
}
