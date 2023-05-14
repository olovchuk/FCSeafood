import {NgModule} from '@angular/core';
import {NgForOf} from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {MaterialModule} from "@modules/material/material.module";
import {ErrorComponent} from "@modules/pages/error/error.component";

const routes: Routes = [
  {
    path: '',
    component: ErrorComponent
  }
];

@NgModule({
  declarations: [ErrorComponent],
  imports: [RouterModule.forChild(routes), MaterialModule, NgForOf],
  exports: [RouterModule]
})
export class ErrorModule {
}
