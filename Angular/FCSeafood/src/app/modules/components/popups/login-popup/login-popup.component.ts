import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, FormGroupDirective, NgForm, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {DialogRef} from "@angular/cdk/dialog";
import {AuthService} from "@common-services/auth/auth.service";
import {SignInResponse} from "@common-data/auth/models/response/sign-in.response";
import {HttpErrorResponse} from "@angular/common/http";
import {ErrorStateMatcher} from "@angular/material/core";
import {MatSnackBar} from "@angular/material/snack-bar";

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
  PreventClose: boolean = false;

  constructor(public dialog: DialogRef<LoginPopupComponent>,
              private router: Router,
              private authService: AuthService,
              private matSnackBar: MatSnackBar) {
    if (this.dialog.config && this.dialog.config.data && this.dialog.config.data.preventClose) {
      this.PreventClose = this.dialog.config.data.preventClose;
    }
  }

  ngOnInit(): void {
  }

  async OnSignIn(): Promise<void> {
    if (this.authorization.status !== 'VALID')
      return;

    let signInResponse: SignInResponse;
    try {
      signInResponse = await this.authService.SignInAsync(this.authorization.value.email, this.authorization.value.password);
      if (signInResponse.isSuccessful) {
        this.dialog.close();
        this.matSnackBar.open("Authorization was successful");
      }
    } catch (e: HttpErrorResponse | any) {
      this.authorization.setErrors({'http': e.error.message});
    }
  }

  async OnClose() {
    if (this.PreventClose) {
      await this.router.navigate(['/home'])
      this.dialog.close()
    } else {
      this.dialog.close()
    }
  }
}

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
