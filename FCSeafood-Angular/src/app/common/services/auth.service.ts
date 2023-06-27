import { EventEmitter, Injectable } from "@angular/core";
import { AuthData } from "@common-data/auth/auth.data";
import { MemoryTimeCacheHelper } from "@common-helpers/memory-time-cache.helper";
import { CookieHelper } from "@common-helpers/cookie.helper";
import { UserInformationState } from "@common-states/user-information.state";
import { UserInformationModel } from "@common-models/user-information.model";
import { SignInRequest } from "@common-data/auth/http/request/sign-in.request";
import { SignInResponse } from "@common-data/auth/http/response/sign-in.response";
import { SignUpRequest } from "@common-data/auth/http/request/sign-up.request";
import { SignOutResponse } from "@common-data/auth/http/response/sign-out.response";
import { SignUpResponse } from "@common-data/auth/http/response/sign-up.response";

export const ACCESS_KEY = 'fcs_access_key';
export const REFRESH_KEY = 'fcs_refresh_key';
export const ACCESS_GUEST_KEY = 'fcs_guest_key';
export const ONE_WEEK_IN_SECONDS = 604800;
export const ONE_DAY_IN_SECONDS = 86400;

export function token(): string {
  const cacheValue = MemoryTimeCacheHelper.Get<string>(ACCESS_KEY);
  if (cacheValue != null) {
    return cacheValue;
  }

  const cookieValue = CookieHelper.getCookie(ACCESS_KEY);

  MemoryTimeCacheHelper.Set<string>(ACCESS_KEY, cookieValue, Date.now() + ONE_WEEK_IN_SECONDS);
  return cookieValue;
}

export function refreshToken() {
  return CookieHelper.getCookie(REFRESH_KEY);
}

export function tokenGuest(): string {
  const cacheValue = MemoryTimeCacheHelper.Get<string>(ACCESS_GUEST_KEY);
  if (cacheValue != null) {
    return cacheValue;
  }

  const cookieValue = CookieHelper.getCookie(ACCESS_GUEST_KEY);

  MemoryTimeCacheHelper.Set<string>(ACCESS_GUEST_KEY, cookieValue, Date.now() + ONE_DAY_IN_SECONDS);
  return cookieValue;
}

@Injectable({providedIn: 'root'})
export class AuthService {
  public signIn$: EventEmitter<SignInResponse> = new EventEmitter<SignInResponse>();
  public signOut$: EventEmitter<SignOutResponse> = new EventEmitter<SignOutResponse>();

  constructor(private authData: AuthData,
              private userInformationState: UserInformationState) {
  }

  async signIn(email: string, password: string): Promise<SignInResponse> {
    const signInRequest: SignInRequest = {
      email: email,
      password: password
    };
    const signInResponse = await this.authData.signIn(signInRequest);
    if (signInResponse.isSuccessful) {
      MemoryTimeCacheHelper.Set<string>(ACCESS_KEY, signInResponse.jwtAuthModel.accessToken, Date.now() + ONE_WEEK_IN_SECONDS);
      this.signIn$.emit(signInResponse);
    }

    return signInResponse;
  }

  async signInGuest(): Promise<SignInResponse> {
    const signInResponse = await this.authData.signInGuest();
    if (signInResponse.isSuccessful)
      MemoryTimeCacheHelper.Set<string>(ACCESS_GUEST_KEY, signInResponse.jwtAuthModel.accessToken, Date.now() + ONE_DAY_IN_SECONDS);

    return signInResponse;
  }

  async signUp(email: string, password: string, firstName: string, lastName: string): Promise<SignUpResponse> {
    const signUpRequest: SignUpRequest = {
      email: email,
      password: password,
      firstName: firstName,
      lastName: lastName
    }

    return await this.authData.signUp(signUpRequest);
  }

  signOut() {
    CookieHelper.deleteCookie(ACCESS_KEY);
    CookieHelper.deleteCookie(REFRESH_KEY);
    MemoryTimeCacheHelper.Delete(ACCESS_KEY);
    this.userInformationState.userInformation = new UserInformationModel();
    this.signOut$.emit({isSuccessful: true, message: ''});
  }

  async resetPassword(): Promise<void> {
    await this.authData.resetPassword();
  }
}
