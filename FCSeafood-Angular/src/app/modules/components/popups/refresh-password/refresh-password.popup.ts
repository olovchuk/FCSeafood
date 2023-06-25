import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { DialogRef } from "@angular/cdk/dialog";
import { MessageHelper } from "@common-helpers/message.helper";

@Component({
  selector: 'refresh-password-popup',
  templateUrl: './refresh-password.popup.html',
  styleUrls: ['./refresh-password.popup.scss']
})
export class RefreshPasswordPopup {
  isShowErrors: boolean = false;
  refreshPasswordFormGroup: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email])
  });

  constructor(private dialogRef: DialogRef<RefreshPasswordPopup>,
              private messageHelper: MessageHelper) {
  }

  confirm(): void {
    if (this.refreshPasswordFormGroup.status !== 'VALID') {
      this.isShowErrors = true;
      return;
    }

    //TODO: SendEmail
    this.messageHelper.success('The message was sent successfully. Check your mail');
    this.dialogRef.close();
  }
}
