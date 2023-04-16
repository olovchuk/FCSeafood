import {Component} from '@angular/core';
import {AuthStateService} from "@common-services/auth-sate/auth-state.service";
import {MatDialog} from "@angular/material/dialog";
import {AuthService} from "@common-services/auth/auth.service";
import {LoginPopupComponent} from "../popups/login-popup/login-popup.component";
import {UserInformationState} from "@common-states/user-information.state";
import {RoleType} from "../../../common/enums/role.type";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  constructor(private dialog: MatDialog,
              public authStateService: AuthStateService,
              private authService: AuthService,
              public userInformationState: UserInformationState) {
  }

  openLoginPopup() {
    const loginPopup = this.dialog.open(LoginPopupComponent, {maxWidth: '95 vw'});
  }

  async OnSignOutClick(): Promise<void> {
    this.authService.SignOut();
  }

  protected readonly RoleType = RoleType;
}
