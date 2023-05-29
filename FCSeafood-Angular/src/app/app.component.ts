import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from "rxjs";
import { UserInformationStateService } from "@common-services/user-information-state/user-information-state";
import { UserInformationData } from "@common-data/user-information/user-information.data";
import { AuthService } from "@common-services/auth.service";
import { SignInResponse } from "@common-data/auth/http/response/sign-in.response";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'Fresh Catch';

  signInSubscription: Subscription;

  constructor(private authService: AuthService,
              private userInformationData: UserInformationData,
              private userInformationStateService: UserInformationStateService) {
    this.signInSubscription = authService.signIn$.subscribe(next => this._onSignIn(next));
  }

  async ngOnInit(): Promise<void> {
    // TODO: Cookie popup

    await this.userInformationStateService.init();
  }

  ngOnDestroy(): void {
    if (this.signInSubscription) {
      this.signInSubscription.unsubscribe();
    }
  }

  private async _onSignIn(res: SignInResponse): Promise<void> {
    if (res.isSuccessful) {
      const userInformation = await this.userInformationData.getUserInformation()
      if (userInformation.isSuccessful)
        this.userInformationStateService.state.userInformation = userInformation.userInformationModel;
    }
  }
}
