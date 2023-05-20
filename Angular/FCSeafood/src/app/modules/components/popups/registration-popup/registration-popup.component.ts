import {Component} from '@angular/core';
import {ErrorStateMatcher} from "@angular/material/core";
import {AbstractControl, FormControl, FormGroup, FormGroupDirective, NgForm, ValidationErrors, Validators} from "@angular/forms";
import {HttpErrorResponse} from "@angular/common/http";
import {AuthService} from "@common-services/auth/auth.service";
import {DialogRef} from "@angular/cdk/dialog";
import {MatSnackBar} from "@angular/material/snack-bar";
import {MatDialog} from "@angular/material/dialog";
import {LoginPopupComponent} from "@modules/components/popups/login-popup/login-popup.component";

@Component({
  selector: 'app-registration-popup',
  templateUrl: './registration-popup.component.html',
  styleUrls: ['./registration-popup.component.scss']
})
export class RegistrationPopupComponent {
  matcher = new MyErrorStateMatcher();
  registration: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    firstName: new FormControl('', [Validators.required, Validators.minLength(2)]),
    lastName: new FormControl('', [Validators.required, Validators.minLength(2)]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    confirmPassword: new FormControl('')
  }, {validators: this.passwordMatchValidator});

  showPassword: boolean = false;

  constructor(private dialog: MatDialog,
              public dialogRef: DialogRef<RegistrationPopupComponent>,
              private authService: AuthService,
              private matSnackBar: MatSnackBar) {
  }

  passwordMatchValidator(control: AbstractControl): ValidationErrors | null {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;

    if (password !== confirmPassword) {
      control.get("confirmPassword")?.setErrors({passwordMismatch: true});
      return {passwordMismatch: true};
    } else {
      return null;
    }
  };

  async signUp() {
    if (this.registration.status !== 'VALID')
      return;

    try {
      let signInResponse = await this.authService.SignUpAsync(this.registration.value.email, this.registration.value.password, this.registration.value.firstName, this.registration.value.lastName);
      if (signInResponse.isSuccessful) {
        this.matSnackBar.open("Registration was successful");
        this.dialogRef.close();
        this.dialog.open(LoginPopupComponent, {
          panelClass: ['animate__animated', 'animate__slideInRight', 'custom-container'],
          position: {right: '0%'},
          minHeight: '100vh',
          width: '550px',
          maxWidth: '100vw'
        });
      }
    } catch (e: HttpErrorResponse | any) {
      this.registration.setErrors({'http': e.error.message});
    }
  }

  async signUpViaFacebook(): Promise<void> {

  }

  async signUpViaGoogle(): Promise<void> {

  }
}

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
