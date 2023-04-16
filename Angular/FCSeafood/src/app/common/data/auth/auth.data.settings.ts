import {Injectable} from "@angular/core";
import {AppSettings} from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class AuthDataSettings {
  private _signInEndpoint: string = '/api/Auth/SignIn';
  signInEndpointUrl: string = AppSettings.webApiHostUrl + this._signInEndpoint;

  private _signInRefreshEndpoint: string = '/api/Auth/SignInRefresh';
  signInRefreshEndpointUrl: string = AppSettings.webApiHostUrl + this._signInRefreshEndpoint;
}
