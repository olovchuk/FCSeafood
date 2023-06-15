import { NgModule } from '@angular/core';
import { NgOptimizedImage } from '@angular/common';
import { RouterModule } from "@angular/router";
import { SignInPopup } from './sign-in/sign-in.popup';
import { ReactiveFormsModule } from "@angular/forms";
import { MaterialModule } from "../../material/material.module";
import { SignUpPopup } from "@modules-components/popups/sign-up/sign-up.popup";
import { PrimengModule } from "@modules/primeng/primeng.module";
import { CartPopup } from './cart/cart.popup';
import { CartCardComponent } from './cart/cart.card/cart.card.component';
import { InputTextAreaPopup } from './input-text-area/input-text-area.popup';

@NgModule({
  declarations: [
    SignInPopup,
    SignUpPopup,
    CartPopup,
    CartCardComponent,
    InputTextAreaPopup
  ],
  exports: [
    SignInPopup,
    SignUpPopup,
    CartPopup
  ],
  imports: [
    RouterModule,
    NgOptimizedImage,
    PrimengModule,
    MaterialModule,
    ReactiveFormsModule
  ]
})
export class PopupsModule {
}
