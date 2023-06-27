import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { firstValueFrom, Observable } from "rxjs";
import { AuthDataSettings } from "@common-data/auth/auth.data.settings";
import { SignInRequest } from "@common-data/auth/http/request/sign-in.request";
import { SignInResponse } from "@common-data/auth/http/response/sign-in.response";
import { SignInRefreshRequest } from "@common-data/auth/http/request/sign-in-refresh.request";
import { SignInRefreshResponse } from "@common-data/auth/http/response/sign-in-refresh.response";
import { SignUpRequest } from "@common-data/auth/http/request/sign-up.request";
import { SignUpResponse } from "@common-data/auth/http/response/sign-up.response";
import { MessageHelper } from "@common-helpers/message.helper";
import { EmptyResponse } from "../../http/response/empty.response";

@Injectable({providedIn: 'root'})
export class AuthData {
  constructor(private settings: AuthDataSettings,
              private http: HttpClient,
              private messageHelper: MessageHelper) {
  }

  async signIn(SignInRequest: SignInRequest): Promise<SignInResponse> {
    const response = await firstValueFrom(this.http.post<SignInResponse>(this.settings.signInEndpointUrl, SignInRequest));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async signInGuest(): Promise<SignInResponse> {
    const response = await firstValueFrom(this.http.post<SignInResponse>(this.settings.signInGuestEndpoint, {}));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  signInRefresh$(signInRefreshRequest: {
    RefreshToken: string
  }): Observable<SignInRefreshResponse> {
    return this.http.post<SignInRefreshResponse>(this.settings.signInRefreshEndpointUrl, signInRefreshRequest);
  }

  async signInRefresh(signInRefreshRequest: SignInRefreshRequest): Promise<SignInRefreshResponse> {
    try {
      return await firstValueFrom(this.http.post<SignInRefreshResponse>(this.settings.signInRefreshEndpointUrl, signInRefreshRequest));
    } catch (e) {
      return new SignInRefreshResponse();
    }
  }

  async signUp(signUpRequest: SignUpRequest): Promise<SignUpResponse> {
    const response = await firstValueFrom(this.http.post<SignUpResponse>(this.settings.signUpEndpointUrl, signUpRequest));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async resetPassword(): Promise<void> {
    const response = await firstValueFrom(this.http.post<EmptyResponse>(this.settings.resetPasswordEndpoint, {}));
    if (response.isSuccessful)
      this.messageHelper.success("The message was sent successfully, check your mail");

    if (!response.isSuccessful)
      this.messageHelper.error(response.message);
  }
}
