import { Injectable } from "@angular/core";
import { UserInformationModel } from "@common-models/user-information.model";

@Injectable({providedIn: 'root'})
export class UserInformationState {
  userInformation: UserInformationModel = new UserInformationModel();

  ResolveInit: Function = new Function;
  Init = new Promise((resolve, reject) => {
    this.ResolveInit = resolve;
  })
}
