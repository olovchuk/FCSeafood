import {Component, OnDestroy, OnInit} from '@angular/core';
import {Subscription} from "rxjs";
import {AuthService, GetToken} from "@common-services/auth/auth.service";
import {UserInformationData} from "@common-data/user-information/user-information.data";
import {UserInformationStateService} from "@common-services/user-information-sate/user-information-state.service";
import {SignInResponse} from "@common-data/auth/models/response/sign-in.response";
import {CommonDataStateService} from "@common-services/common-data-state/common-data-state.service";

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
              private userInformationStateService: UserInformationStateService,
              private commonDataStateService: CommonDataStateService) {
    this.signInSubscription = authService.signIn$.subscribe(next => this._onSignIn(next));
  }

  async ngOnInit(): Promise<void> {
    // TODO: Cookie popup

    await this.userInformationStateService.Init();
    await this.commonDataStateService.init();
  }

  ngOnDestroy(): void {
    if (this.signInSubscription) {
      this.signInSubscription.unsubscribe();
    }
  }

  private async _onSignIn(res: SignInResponse): Promise<void> {
    if (res.isSuccessful) {
      const userInformation = await this.userInformationData.GetUserInformationAsync()
      if (userInformation.isSuccessful)
        this.userInformationStateService.State.userInformation = userInformation.userInformationModel;
    }
  }
}
