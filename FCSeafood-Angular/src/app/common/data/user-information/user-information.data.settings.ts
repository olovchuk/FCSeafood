import { Injectable } from "@angular/core";
import { AppSettings } from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class UserInformationDataSettings {
  private _getUserInformationEndpoint: string = '/api/User/GetUserInformation';
  getUserInformationEndpoint: string = AppSettings.webApiHostUrl + this._getUserInformationEndpoint;

  private _getUserEndpoint: string = '/api/User/GetUser';
  getUserEndpoint: string = AppSettings.webApiHostUrl + this._getUserEndpoint;

  private _updateUserAddressEndpoint: string = '/api/User/UpdateUserAddress';
  updateUserAddressEndpoint: string = AppSettings.webApiHostUrl + this._updateUserAddressEndpoint;
}
