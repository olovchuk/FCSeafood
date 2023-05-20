import {Injectable} from "@angular/core";
import {firstValueFrom, Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {SignInResponse} from "./models/response/sign-in.response";
import {SignInRefreshResponse} from "./models/response/sign-in-refresh.response";
import {SignInRequest} from "./models/request/sign-in.request";
import {SignInRefreshRequest} from "./models/request/sign-in-refresh.request";
import {AuthDataSettings} from "./auth.data.settings";
import {SignUpRequest} from "@common-data/auth/models/request/sign-up.request";
import {SignUpResponse} from "@common-data/auth/models/response/sign-up.response";

@Injectable({providedIn: 'root'})
export class AuthData {
  constructor(private settings: AuthDataSettings,
              private http: HttpClient) {
  }

  async SignInAsync(SignInRequest: SignInRequest): Promise<SignInResponse> {
    return await firstValueFrom(this.http.post<SignInResponse>(this.settings.signInEndpointUrl, SignInRequest));
  }

  SignInRefresh$(signInRefreshRequest: { RefreshToken: string }): Observable<SignInRefreshResponse> {
    return this.http.post<SignInRefreshResponse>(this.settings.signInRefreshEndpointUrl, signInRefreshRequest);
  }

  async SignInRefreshAsync(signInRefreshRequest: SignInRefreshRequest): Promise<SignInRefreshResponse> {
    try {
      return await firstValueFrom(this.http.post<SignInRefreshResponse>(this.settings.signInRefreshEndpointUrl, signInRefreshRequest));
    } catch (e) {
      return new SignInRefreshResponse();
    }
  }

  async SignUpAsync(signUpRequest: SignUpRequest): Promise<SignUpResponse> {
    return await firstValueFrom(this.http.post<SignUpResponse>(this.settings.signUpEndpointUrl, signUpRequest));
  }
}
