import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from "@angular/forms";
import { DialogRef } from "@angular/cdk/dialog";
import { HttpErrorResponse } from "@angular/common/http";
import { MessageHelper } from "@common-helpers/message.helper";
import { AuthService } from "@common-services/auth.service";
import { MatDialog } from "@angular/material/dialog";
import { SignInPopup } from "@modules-components/popups/sign-in/sign-in.popup";

@Component({
  selector: 'sign-up-popup',
  templateUrl: './sign-up.popup.html',
  styleUrls: ['./sign-up.popup.scss']
})
export class SignUpPopup {
  isShowErrors: boolean = false;

  signUpFormGroup: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    firstName: new FormControl('', [Validators.required, Validators.minLength(2)]),
    lastName: new FormControl('', [Validators.required, Validators.minLength(2)]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    confirmPassword: new FormControl('')
  }, {validators: this.passwordMatchValidator});

  constructor(private dialogRef: DialogRef<SignUpPopup>,
              private dialog: MatDialog,
              private messageHelper: MessageHelper,
              private authService: AuthService) {
  }

  async signUp(): Promise<void> {
    if (this.signUpFormGroup.status !== 'VALID') {
      this.isShowErrors = true;
      return;
    }

    try {
      let signInResponse = await this.authService.signUp(this.signUpFormGroup.value.email, this.signUpFormGroup.value.password, this.signUpFormGroup.value.firstName, this.signUpFormGroup.value.lastName);
      if (signInResponse.isSuccessful) {
        this.messageHelper.success("Registration was successful");
        this.dialogRef.close();
        this.dialog.open(SignInPopup, {
          panelClass: ['animate__animated', 'animate__slideInRight', 'custom-container', 'border-primary-left'],
          position: {right: '0%'},
          minHeight: '100vh',
          width: '550px',
          maxWidth: '100vw'
        });
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

  passwordMatchValidator(control: AbstractControl): ValidationErrors | null {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;

    if (password !== confirmPassword) {
      control.get("confirmPassword")?.setErrors({passwordMismatch: true});
      return {passwordMismatch: true};
    }
    else {
      return null;
    }
  };
}
