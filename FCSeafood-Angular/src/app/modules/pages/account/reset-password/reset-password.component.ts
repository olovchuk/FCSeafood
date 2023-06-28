import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from "@angular/forms";
import { AuthStateService } from "@common-services/auth-state/auth-sate.service";
import { RouteHelper } from "@common-helpers/route.helper";
import { AuthService } from "@common-services/auth.service";
import { UserService } from "@common-services/user.service";
import { MessageHelper } from "@common-helpers/message.helper";

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['../account.component.scss']
})
export class ResetPasswordComponent implements OnInit {
  isShowErrors: boolean = false;
  refreshPasswordFormGroup: FormGroup = new FormGroup({
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    confirmPassword: new FormControl('')
  }, {validators: this.passwordMatchValidator});

  constructor(private routeHelper: RouteHelper,
              private authStateService: AuthStateService,
              private authService: AuthService,
              private userService: UserService,
              private messageHelper: MessageHelper) {
  }

  async ngOnInit(): Promise<void> {
    if (!this.authStateService.token.UserId) {
      await this.routeHelper.goToError();
      return;
    }

    const code = this.routeHelper.getQueryParameter(this.routeHelper.query.code);
    if (code && parseInt(code) && !await this.authService.isExistsResetPasswordCode(parseInt(code)))
      await this.routeHelper.goToHome();
  }

  async confirm(): Promise<void> {
    if (this.refreshPasswordFormGroup.status !== 'VALID') {
      this.isShowErrors = true;
      return;
    }

    await this.userService.updateUserPassword({newPassword: this.refreshPasswordFormGroup.get('password')?.value});
    this.messageHelper.successSticky("Password successfully changed!");
    await this.routeHelper.goToHome();
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
}
