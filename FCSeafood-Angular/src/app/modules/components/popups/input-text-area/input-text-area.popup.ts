import { Component, Input } from '@angular/core';
import { MatDialogRef } from "@angular/material/dialog";

@Component({
  selector: 'input-text-area-popup',
  templateUrl: './input-text-area.popup.html',
  styleUrls: ['./input-text-area.popup.scss']
})
export class InputTextAreaPopup {
  title!: string;
  maxLength!: number;

  constructor(private dialogRef: MatDialogRef<InputTextAreaPopup>) {
  }

  ok(value: string) {
    this.dialogRef.close(value);
  }
}
