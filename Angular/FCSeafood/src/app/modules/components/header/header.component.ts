import {Component} from '@angular/core';
import {AuthStateService} from "@common-services/auth-sate/auth-state.service";
import {MatDialog} from "@angular/material/dialog";
import {AuthService} from "@common-services/auth/auth.service";
import {LoginPopupComponent} from "../popups/login-popup/login-popup.component";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  constructor(private dialog: MatDialog,
              public authStateService: AuthStateService,
              private authService: AuthService) {
  }

  openSignInPopup() {
    const loginPopup = this.dialog.open(LoginPopupComponent, {
      panelClass: ['animate__animated', 'animate__slideInRight', 'custom-container'],
      position: {right: '0%'},
      minHeight: '100vh',
      width: '550px',
      maxWidth: '100vw'
    });
  }

  async signOut(): Promise<void> {
    this.authService.SignOut();
  }
}
