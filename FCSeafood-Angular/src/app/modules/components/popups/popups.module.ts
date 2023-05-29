import { NgModule } from '@angular/core';
import { NgOptimizedImage } from '@angular/common';
import { RouterModule } from "@angular/router";
import { SignInPopup } from './sign-in/sign-in.popup';
import { ReactiveFormsModule } from "@angular/forms";
import { MaterialModule } from "../../material/material.module";
import { SignUpPopup } from "@modules-components/popups/sign-up/sign-up.popup";
import { PrimengModule } from "@modules/primeng/primeng.module";

@NgModule({
  declarations: [
    SignInPopup,
    SignUpPopup
  ],
  exports: [
    SignInPopup,
    SignUpPopup
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
