import { Injectable } from "@angular/core";
import { AppSettings } from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class UserInformationDataSettings {
  private _getUserInformationEndpoint: string = '/api/User/GetUserInformation';
  getUserInformationEndpoint: string = AppSettings.webApiHostUrl + this._getUserInformationEndpoint;

  private _getUserEndpoint: string = '/api/User/GetUser';
  getUserEndpoint: string = AppSettings.webApiHostUrl + this._getUserEndpoint;

  private _getUserCredentialsEndpoint: string = '/api/User/GetUserCredentials';
  getUserCredentialsEndpoint: string = AppSettings.webApiHostUrl + this._getUserCredentialsEndpoint;

  private _updateUserAddressEndpoint: string = '/api/User/UpdateUserAddress';
  updateUserAddressEndpoint: string = AppSettings.webApiHostUrl + this._updateUserAddressEndpoint;

  private _updateUserInformationEndpoint: string = '/api/User/UpdateUserInformation';
  updateUserInformationEndpoint: string = AppSettings.webApiHostUrl + this._updateUserInformationEndpoint;

  private _updateUserPasswordEndpoint: string = '/api/User/UpdateUserPassword';
  updateUserPasswordEndpoint: string = AppSettings.webApiHostUrl + this._updateUserPasswordEndpoint;
}
