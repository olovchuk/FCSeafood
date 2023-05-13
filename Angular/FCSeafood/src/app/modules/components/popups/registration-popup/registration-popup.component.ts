import {Component} from '@angular/core';
import {ErrorStateMatcher} from "@angular/material/core";
import {AbstractControl, FormControl, FormGroup, FormGroupDirective, NgForm, ValidationErrors, Validators} from "@angular/forms";

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

  constructor() {
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
