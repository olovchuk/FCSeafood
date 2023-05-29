import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MessageHelper } from "@common-helpers/message.helper";
import { HttpErrorResponse } from "@angular/common/http";
import { AuthService } from "@common-services/auth.service";
import { DialogRef } from "@angular/cdk/dialog";
import { MatDialog } from "@angular/material/dialog";
import { SignUpPopup } from "@modules-components/popups/sign-up/sign-up.popup";

@Component({
  selector: 'sign-in-popup',
  templateUrl: './sign-in.popup.html',
  styleUrls: ['./sign-in.popup.scss']
})
export class SignInPopup {
  isShowErrors: boolean = false;

  signInFormGroup: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.min(8)])
  });

  constructor(private dialogRef: DialogRef<SignInPopup>,
              private dialog: MatDialog,
              private messageHelper: MessageHelper,
              private authService: AuthService) {
  }

  async signIn(): Promise<void> {
    if (this.signInFormGroup.status !== 'VALID') {
      this.isShowErrors = true;
      return;
    }

    try {
      let signInResponse = await this.authService.signIn(this.signInFormGroup.value.email, this.signInFormGroup.value.password);
      if (signInResponse.isSuccessful) {
        this.dialogRef.close();
        this.messageHelper.success("Authorization was successful");
      }
    } catch (e: HttpErrorResponse | any) {
      this.messageHelper.clear();
      this.messageHelper.errorSticky("Failed to load resource. Please try again later.");
    }
  }

  async signInViaFacebook(): Promise<void> {

  }

  async signInViaGoogle(): Promise<void> {

  }

  async openSignUpPopup(): Promise<void> {
    this.dialogRef.close();
    this.dialog.open(SignUpPopup, {
      panelClass: ['animate__animated', 'animate__slideInRight', 'custom-container', 'border-primary-left'],
      position: {right: '0%'},
      minHeight: '100vh',
      width: '550px',
      maxWidth: '100vw'
    });
  }
}
