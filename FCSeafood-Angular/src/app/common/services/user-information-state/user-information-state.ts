import { Injectable } from "@angular/core";
import { UserInformationState } from "@common-states/user-information.state";
import { UserInformationData } from "@common-data/user-information/user-information.data";

@Injectable({providedIn: 'root'})
export class UserInformationStateService {
  constructor(private userInformationState: UserInformationState,
              private userInformationDate: UserInformationData) {
  }

  get state(): UserInformationState {
    return this.userInformationState;
  }

  async init(): Promise<UserInformationState> {
    const result = await this.userInformationDate.getUserInformation();
    if (result.isSuccessful)
      this.userInformationState.userInformation = result.userInformationModel;

    this.userInformationState.ResolveInit(null);
    return this.userInformationState;
  }
}
