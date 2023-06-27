import { Injectable } from "@angular/core";
import { AppSettings } from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class AuthDataSettings {
  private _signInEndpoint: string = '/api/Auth/SignIn';
  signInEndpointUrl: string = AppSettings.webApiHostUrl + this._signInEndpoint;

  private _signInGuestEndpoint: string = '/api/Auth/SignInGuest';
  signInGuestEndpoint: string = AppSettings.webApiHostUrl + this._signInGuestEndpoint;

  private _signInRefreshEndpoint: string = '/api/Auth/SignInRefresh';
  signInRefreshEndpointUrl: string = AppSettings.webApiHostUrl + this._signInRefreshEndpoint;

  private _signUpEndpoint: string = '/api/Auth/SignUp';
  signUpEndpointUrl: string = AppSettings.webApiHostUrl + this._signUpEndpoint;

  private _resetPasswordEndpoint: string = '/api/Auth/ResetPassword';
  resetPasswordEndpoint: string = AppSettings.webApiHostUrl + this._resetPasswordEndpoint;

  private _forgotPasswordEndpoint: string = '/api/Auth/ForgotPassword';
  forgotPasswordEndpoint: string = AppSettings.webApiHostUrl + this._forgotPasswordEndpoint;
}
