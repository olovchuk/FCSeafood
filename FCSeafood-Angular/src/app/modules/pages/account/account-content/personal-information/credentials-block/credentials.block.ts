import { Component, Input, OnInit } from '@angular/core';
import { UserCredentials } from "@modules-pages/account/account-content/personal-information/personal-information.component";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { RefreshPasswordPopup } from "@modules-components/popups/refresh-password/refresh-password.popup";
import { MatDialog } from "@angular/material/dialog";
import { AuthService } from "@common-services/auth.service";

@Component({
  selector: 'personal-credentials-block',
  templateUrl: './credentials.block.html',
  styleUrls: ['../personal-information.component.scss']
})
export class CredentialsBlock implements OnInit {
  @Input("userCredentials") userCredentials!: UserCredentials;

  isShowErrors: boolean = false;
  credentialsFormGroup: FormGroup = new FormGroup({
    isEdit: new FormControl(false),
    email: new FormControl('', [Validators.required, Validators.email])
  });

  constructor(private dialog: MatDialog,
              private authService: AuthService) {
  }

  ngOnInit(): void {
    this.credentialsFormGroup.controls['email'].setValue(this.userCredentials.email);
  }

  showRefreshPasswordPopup() {
    const refreshPasswordPopup = this.dialog.open(RefreshPasswordPopup, {
      panelClass: ['animate__animated', 'animate__slideInUp', 'border-primary']
    });
  }

  async resetPassword(): Promise<void> {
    await this.authService.resetPassword();
  }
}
