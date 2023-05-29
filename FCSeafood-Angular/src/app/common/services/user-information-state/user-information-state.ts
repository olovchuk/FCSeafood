import { Injectable } from "@angular/core";
import { UserInformationState } from "@common-states/user-information.state";
import { UserInformationData } from "@common-data/user-information/user-information.data";
import { AuthStateService } from "@common-services/auth-state/auth-sate.service";

@Injectable({providedIn: 'root'})
export class UserInformationStateService {
  constructor(private userInformationState: UserInformationState,
              private userInformationDate: UserInformationData,
              private authStateService: AuthStateService) {
  }

  get state(): UserInformationState {
    return this.userInformationState;
  }

  async init(): Promise<UserInformationState> {
    if (this.authStateService.IsAuthorized) {
      const result = await this.userInformationDate.getUserInformation();
      if (result.isSuccessful)
        this.userInformationState.userInformation = result.userInformationModel;
    }

    this.userInformationState.ResolveInit(null);
    return this.userInformationState;
  }
}
