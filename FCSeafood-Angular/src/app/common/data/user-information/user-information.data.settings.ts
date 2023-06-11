import { Injectable } from "@angular/core";
import { AppSettings } from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class UserInformationDataSettings {
  private _getUserInformationEndpoint: string = '/api/User/GetUserInformation';
  getUserInformationEndpoint: string = AppSettings.webApiHostUrl + this._getUserInformationEndpoint;
}
