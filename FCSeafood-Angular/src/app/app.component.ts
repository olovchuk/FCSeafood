import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from "rxjs";
import { UserInformationStateService } from "@common-services/user-information-state/user-information-state";
import { UserInformationData } from "@common-data/user-information/user-information.data";
import { ACCESS_GUEST_KEY, AuthService, tokenGuest } from "@common-services/auth.service";
import { SignInResponse } from "@common-data/auth/http/response/sign-in.response";
import { AuthStateService } from "@common-services/auth-state/auth-sate.service";
import { MemoryTimeCacheHelper } from "@common-helpers/memory-time-cache.helper";
import { CookieHelper } from "@common-helpers/cookie.helper";
import { SignUpResponse } from "@common-data/auth/http/response/sign-up.response";
import { OrderStateService } from "@common-services/order-state/order-state.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'Fresh Catch';

  signInSubscription: Subscription;
  signOutSubscription: Subscription;

  constructor(private authService: AuthService,
              private authStateService: AuthStateService,
              private userInformationData: UserInformationData,
              private userInformationStateService: UserInformationStateService,
              private orderStateService: OrderStateService) {
    this.signInSubscription = authService.signIn$.subscribe(next => this._onSignIn(next));
    this.signOutSubscription = authService.signOut$.subscribe(next => this._onSignOut(next));
  }

  async ngOnInit(): Promise<void> {
    // TODO: Cookie popup

    if (!this.authStateService.IsAuthorized && !tokenGuest()) {
      await this.authService.signInGuest();
    }

    await this.orderStateService.init();
    await this.userInformationStateService.init();
  }

  ngOnDestroy(): void {
    if (this.signInSubscription) {
      this.signInSubscription.unsubscribe();
    }

    if (this.signOutSubscription) {
      this.signOutSubscription.unsubscribe();
    }
  }

  private async _onSignIn(signInResponse: SignInResponse): Promise<void> {
    if (signInResponse.isSuccessful) {
      const userInformation = await this.userInformationData.getUserInformation()
      if (userInformation.isSuccessful)
        this.userInformationStateService.state.userInformation = userInformation.userInformationModel;

      MemoryTimeCacheHelper.Delete(ACCESS_GUEST_KEY);
      CookieHelper.deleteCookie(ACCESS_GUEST_KEY);
    }
  }

  private async _onSignOut(signUpResponse: SignUpResponse): Promise<void> {
    if (signUpResponse.isSuccessful) {
      await this.authService.signInGuest();
    }
  }
}
