import {Injectable} from "@angular/core";
import {AuthStateService} from "../auth-sate/auth-state.service";
import {UserInformationData} from "../../data/user-information/user-information.data";
import {UserInformationState} from "../../states/user-information.state";
import {UserInformationModel} from "@common-data/user-information/models/common/user-information.model";


@Injectable({providedIn: 'root'})
export class UserInformationStateService {
  constructor(private userInformationState: UserInformationState,
              private userInformationDate: UserInformationData,
              private authStateService: AuthStateService) {
  }

  get State(): UserInformationState {
    return this.userInformationState;
  }

  async Init(): Promise<UserInformationState> {
    if (this.authStateService.IsAuthorized) {
      const result = await this.userInformationDate.GetUserInformationAsync();
      console.log("result:", result);
      console.log("result.userInformation:", result.userInformationModel);
      console.dir(result.userInformationModel)
      if (result.isSuccessful)
        this.userInformationState.userInformation = result.userInformationModel;
    }
    this.userInformationState.ResolveInit(null);
    return this.userInformationState;
  }
}
