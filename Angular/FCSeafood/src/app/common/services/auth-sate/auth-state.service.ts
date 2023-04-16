import {Injectable} from "@angular/core";
import {AuthState} from "../../states/auth.state";
import {CookieHelper} from "../../helpers/cookie.helper";
import {TokenModel} from "../../models/token.model";
import {AuthData} from "../../data/auth/auth.data";
import {ACCESS_KEY, GetRefreshToken, GetToken, ONE_WEEK_IN_SECONDS, REFRESH_KEY} from "../auth/auth.service";
import {MemoryTimeCacheHelper} from "../../helpers/memory-time-cache.helper";
import {JwtHelperService} from "@auth0/angular-jwt";

@Injectable({providedIn: 'root'})
export class AuthStateService {
  IsPendingRefreshToken: boolean = false;

  constructor(private authState: AuthState,
              private authData: AuthData,
              private jwtHelper: JwtHelperService) {
  }

  get State(): AuthState {
    return this.authState;
  }

  get IsAuthorized(): boolean {
    if (this.IsPendingRefreshToken) {
      return false;
    }

    const token = GetToken();
    try {
      if (token && !this.jwtHelper.isTokenExpired()) {
        this.authState.isAuthorized = true;
        return this.authState.isAuthorized;
      }
    } catch (ex) {
      CookieHelper.deleteCookie(ACCESS_KEY);
      this.authState.isAuthorized = false;
      return this.authState.isAuthorized;
    }

    const refreshToken = GetRefreshToken();
    if (!refreshToken) {
      this.authState.isAuthorized = false;
      return this.authState.isAuthorized;
    }

    this.IsPendingRefreshToken = true;
    this.authData.SignInRefreshAsync({
      refreshToken: refreshToken
    }).then((d) => {
      if (!d.isSuccessful) {
        CookieHelper.deleteCookie(REFRESH_KEY);
      } else {

        MemoryTimeCacheHelper.Set<string>(ACCESS_KEY, d.jwtAuthModel.AccessToken, Date.now() + ONE_WEEK_IN_SECONDS);
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

  get Token(): TokenModel {
    if (this.IsAuthorized) {
      const tokenString = GetToken();
      if (tokenString) {
        const token = this.jwtHelper.decodeToken(tokenString);

        this.authState.token.userId = token.userId;
        this.authState.token.email = token.email;
        this.authState.token.roleType = parseInt(token.roleType);
      } else
        this.authState.token = new TokenModel();
    } else
      this.authState.token = new TokenModel();

    return this.authState.token;
  }

  set SetReturnUrl(url: string) {
    this.authState.returnUrl = url;
  }
}
