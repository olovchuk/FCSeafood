import {EventEmitter, Injectable} from '@angular/core';
import {MemoryTimeCacheHelper} from "../../helpers/memory-time-cache.helper";
import {CookieHelper} from "../../helpers/cookie.helper";
import {SignInResponse} from "../../data/auth/models/response/sign-in.response";
import {SignOutResponse} from "../../data/auth/models/response/sign-out.response";
import {AuthData} from "../../data/auth/auth.data";
import {SignInRequest} from "../../data/auth/models/request/sign-in.request";
import {UserInformationState} from "@common-states/user-information.state";
import {UserInformationModel} from "@common-data/user-information/models/common/user-information.model";

export const ACCESS_KEY = 'fcs_access_key';
export const REFRESH_KEY = 'fcs_refresh_key';
export const ONE_WEEK_IN_SECONDS = 604800;

export function GetToken(): string {
  const cacheValue = MemoryTimeCacheHelper.Get<string>(ACCESS_KEY);
  if (cacheValue != null) {
    return cacheValue;
  }

  const cookieValue = CookieHelper.getCookie(ACCESS_KEY);

  MemoryTimeCacheHelper.Set<string>(ACCESS_KEY, cookieValue, Date.now() + ONE_WEEK_IN_SECONDS);
  return cookieValue;
}

export function GetRefreshToken() {
  return CookieHelper.getCookie(REFRESH_KEY);
}

@Injectable({providedIn: 'root'})
export class AuthService {
  public signIn$: EventEmitter<SignInResponse> = new EventEmitter<SignInResponse>();
  public signOut$: EventEmitter<SignOutResponse> = new EventEmitter<SignOutResponse>();

  constructor(private authData: AuthData,
              private userInformationState: UserInformationState,) {
  }

  async SignInAsync(email: string, password: string): Promise<SignInResponse> {
    const signInRequest: SignInRequest = {
      Email: email,
      Password: password
    };
    const signInResponse = await this.authData.SignInAsync(signInRequest);
    if (signInResponse.isSuccessful)
      MemoryTimeCacheHelper.Set<string>(ACCESS_KEY, signInResponse.jwtAuthModel.AccessToken, Date.now() + ONE_WEEK_IN_SECONDS);
    return signInResponse;
  }

  SignOut() {
    CookieHelper.deleteCookie(ACCESS_KEY);
    CookieHelper.deleteCookie(REFRESH_KEY);
    MemoryTimeCacheHelper.Delete(ACCESS_KEY);
    this.userInformationState.userInformation = new UserInformationModel();
    this.signOut$.emit();
  }
}
