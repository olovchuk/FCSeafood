import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { DialogRef } from "@angular/cdk/dialog";
import { MessageHelper } from "@common-helpers/message.helper";
import { AuthService } from "@common-services/auth.service";

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
              private messageHelper: MessageHelper,
              private authService: AuthService) {
  }

  async confirm(): Promise<void> {
    if (this.refreshPasswordFormGroup.status !== 'VALID') {
      this.isShowErrors = true;
      return;
    }

    await this.authService.forgotPassword(this.refreshPasswordFormGroup.get('email')?.value);
    this.dialogRef.close();
  }
}
