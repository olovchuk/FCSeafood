import { NgModule } from '@angular/core';
import { MatDialogModule, MAT_DIALOG_DEFAULT_OPTIONS } from "@angular/material/dialog";
import { MatTooltipModule } from "@angular/material/tooltip";

@NgModule({
  exports: [
    MatDialogModule,
    MatTooltipModule
  ],
  providers: [
    {provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {autoFocus: false}}
  ]
})
export class MaterialModule {
}
