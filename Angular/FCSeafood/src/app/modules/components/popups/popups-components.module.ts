import {NgModule} from '@angular/core';
import {CommonModule, NgOptimizedImage} from '@angular/common';
import {LoginPopupComponent} from "./login-popup/login-popup.component";
import {MaterialModule} from "../../material/material.module";
import {RouterModule} from "@angular/router";
import {RegistrationPopupComponent} from './registration-popup/registration-popup.component';


@NgModule({
  declarations: [
    LoginPopupComponent,
    RegistrationPopupComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule,
    NgOptimizedImage
  ],
  exports: [
    LoginPopupComponent
  ]
})
export class PopupsComponentsModule {
}
