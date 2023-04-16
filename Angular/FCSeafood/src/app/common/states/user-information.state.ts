import {Injectable} from "@angular/core";
import {UserInformationModel} from "../data/user-information/models/common/user-information.model";

@Injectable({providedIn: 'root'})
export class UserInformationState {
  userInformation: UserInformationModel = new UserInformationModel();

  ResolveInit: Function = new Function;
  Init = new Promise((resolve, reject) => {
    this.ResolveInit = resolve;
  })
}
