import {Injectable} from "@angular/core";
import {AuthStateService} from "../auth-sate/auth-state.service";
import {UserInformationData} from "../../data/user-information/user-information.data";
import {UserInformationState} from "../../states/user-information.state";


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
      const result = await this.userInformationDate.GetUserInformationAsync();
      if (result.isSuccessful)
        this.userInformationState.userInformation = result.userInformationModel;
    }

    this.userInformationState.ResolveInit(null);
    return this.userInformationState;
  }
}
