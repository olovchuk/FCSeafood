import {Injectable} from "@angular/core";
import {firstValueFrom, Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {SignInResponse} from "./models/response/sign-in.response";
import {SignInRefreshResponse} from "./models/response/sign-in-refresh.response";
import {SignInRequest} from "./models/request/sign-in.request";
import {SignInRefreshRequest} from "./models/request/sign-in-refresh.request";
import {AuthDataSettings} from "./auth.data.settings";

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

  async SignInRefreshAsync(SignInRefreshRequest: SignInRefreshRequest): Promise<SignInRefreshResponse> {
    try {
      return await firstValueFrom(this.http.post<SignInRefreshResponse>(this.settings.signInRefreshEndpointUrl, SignInRefreshRequest));
    } catch (e) {
      return new SignInRefreshResponse();
    }
  }
}
