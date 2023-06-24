import { NgModule } from '@angular/core';
import { NgForOf, NgOptimizedImage } from '@angular/common';
import { RouterModule, Routes } from "@angular/router";
import { PrimengModule } from "@modules/primeng/primeng.module";
import { PersonalInformationComponent } from './personal-information/personal-information.component';
import { ReactiveFormsModule } from "@angular/forms";
import { InformationBlock } from './personal-information/information-block/information.block';
import { AddressBlock } from './personal-information/address-block/address.block';
import { PurchasesComponent } from './purchases/purchases.component';
import { PurchasesCard } from './purchases/purchases-card/purchases.card';

const routes: Routes = [
  {path: '', redirectTo: 'personal-information', pathMatch: 'full'},
  {path: 'personal-information', component: PersonalInformationComponent},
  {path: 'purchases', component: PurchasesComponent}
];

@NgModule({
  declarations: [
    PersonalInformationComponent,
    InformationBlock,
    AddressBlock,
    PurchasesComponent,
    PurchasesCard
  ],
  imports: [RouterModule.forChild(routes), PrimengModule, NgForOf, NgOptimizedImage, ReactiveFormsModule],
  exports: [RouterModule]
})
export class AccountContentModule {
}
