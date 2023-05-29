import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import { NgForOf } from '@angular/common';
import { PrimengModule } from "@modules/primeng/primeng.module";
import { ErrorComponent } from "@modules-pages/error/error.component";

const routes: Routes = [
  {
    path: '',
    component: ErrorComponent
  }
];

@NgModule({
  declarations: [ErrorComponent],
  imports: [RouterModule.forChild(routes), PrimengModule, NgForOf],
  exports: [RouterModule]
})
export class ErrorModule {
}
