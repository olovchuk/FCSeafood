import { Injectable } from "@angular/core";
import { ACCESS_KEY, ONE_WEEK_IN_SECONDS, REFRESH_KEY, refreshToken, token } from "@common-services/auth.service";
import { JwtHelperService } from "@auth0/angular-jwt";
import { CookieHelper } from "@common-helpers/cookie.helper";
import { MemoryTimeCacheHelper } from "@common-helpers/memory-time-cache.helper";
import { AuthData } from "@common-data/auth/auth.data";
import { AuthState } from "@common-states/auth.state";
import { TokenModel } from "@common-models/token.model";

@Injectable({providedIn: 'root'})
export class AuthStateService {
  IsPendingRefreshToken: boolean = false;

  constructor(private authState: AuthState,
              private authData: AuthData,
              private jwtHelper: JwtHelperService) {
  }

  get state(): AuthState {
    return this.authState;
  }

  get IsAuthorized(): boolean {
    if (this.IsPendingRefreshToken) {
      return false;
    }

    const _token = token();
    try {
      if (_token && !this.jwtHelper.isTokenExpired()) {
        this.authState.isAuthorized = true;
        return this.authState.isAuthorized;
      }
    } catch (ex) {
      CookieHelper.deleteCookie(ACCESS_KEY);
      this.authState.isAuthorized = false;
      return this.authState.isAuthorized;
    }

    const _refreshToken = refreshToken();
    if (!_refreshToken) {
      this.authState.isAuthorized = false;
      return this.authState.isAuthorized;
    }

    this.IsPendingRefreshToken = true;
    this.authData.signInRefresh({
      refreshToken: _refreshToken
    }).then((d) => {
      if (!d.isSuccessful) {
        CookieHelper.deleteCookie(REFRESH_KEY);
      }
      else {

        MemoryTimeCacheHelper.Set<string>(ACCESS_KEY, d.jwtAuthModel.accessToken, Date.now() + ONE_WEEK_IN_SECONDS);
      }
      this.IsPendingRefreshToken = false;
    });

    try {
      this.authState.isAuthorized = !this.jwtHelper.isTokenExpired();
      return this.authState.isAuthorized;
    } catch (ex) {
      CookieHelper.deleteCookie(ACCESS_KEY);
      this.authState.isAuthorized = false;
      return this.authState.isAuthorized;
    }

    this.authState.isAuthorized = false;
    return this.authState.isAuthorized;
  }

  get token(): TokenModel {
    if (this.IsAuthorized) {
      const _token = token();
      if (_token) {
        const token = this.jwtHelper.decodeToken(_token);
        this.authState.token.UserId = token.UserId;
        this.authState.token.Email = token.Email;
        this.authState.token.RoleType = parseInt(token.RoleType);
      }
      else
        this.authState.token = new TokenModel();
    }
    else
      this.authState.token = new TokenModel();

    return this.authState.token;
  }
}
