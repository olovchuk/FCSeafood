import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, FormGroupDirective, NgForm, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {DialogRef} from "@angular/cdk/dialog";
import {AuthService} from "@common-services/auth/auth.service";
import {HttpErrorResponse} from "@angular/common/http";
import {ErrorStateMatcher} from "@angular/material/core";
import {MatSnackBar} from "@angular/material/snack-bar";
import {RegistrationPopupComponent} from "@modules/components/popups/registration-popup/registration-popup.component";
import {MatDialog} from "@angular/material/dialog";

@Component({
  selector: 'app-login-popup',
  templateUrl: './login-popup.component.html',
  styleUrls: ['./login-popup.component.scss']
})
export class LoginPopupComponent implements OnInit {
  matcher = new MyErrorStateMatcher();
  authorization: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.min(8)])
  });

  showPassword: boolean = false;

  constructor(private dialog: MatDialog,
              public dialogRef: DialogRef<LoginPopupComponent>,
              private router: Router,
              private authService: AuthService,
              private matSnackBar: MatSnackBar) {
  }

  ngOnInit(): void {
  }

  async signIn(): Promise<void> {
    if (this.authorization.status !== 'VALID')
      return;

    try {
      let signInResponse = await this.authService.SignInAsync(this.authorization.value.email, this.authorization.value.password);
      if (signInResponse.isSuccessful) {
        this.dialogRef.close();
        this.matSnackBar.open("Authorization was successful");
      }
    } catch (e: HttpErrorResponse | any) {
      this.authorization.setErrors({'http': e.error.message});
    }
  }

  async signInViaFacebook(): Promise<void> {

  }

  async signInViaGoogle(): Promise<void> {

  }

  async openSignUpPopup(): Promise<void> {
    this.dialogRef.close();
    this.dialog.open(RegistrationPopupComponent, {
      panelClass: ['animate__animated', 'animate__slideInRight', 'custom-container'],
      position: {right: '0%'},
      minHeight: '100vh',
      width: '550px',
      maxWidth: '100vw'
    });
  }
}

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
