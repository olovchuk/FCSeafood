import {Injectable} from "@angular/core";
import {BehaviorSubject, catchError, filter, Observable, switchMap, take, throwError} from "rxjs";
import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {AuthData} from "@common-data/auth/auth.data";
import {SignInRefreshResponse} from "@common-data/auth/models/response/sign-in-refresh.response";
import {MemoryTimeCacheHelper} from "@common-helpers/memory-time-cache.helper";
import {
  ACCESS_KEY,
  AuthService,
  GetRefreshToken,
  GetToken,
  ONE_WEEK_IN_SECONDS
} from "@common-services/auth/auth.service";

@Injectable()
export class RefreshTokenInterceptor implements HttpInterceptor {
  private refreshTokenInProgress = false;

  private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(
    null
  );

  constructor(public auth: AuthData,
              public authService: AuthService) {
  }

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((error) => {
        if (request.url.includes("SignIn") || request.url.includes("SignInRefresh")) {
          this.authService.SignOut();
          return throwError(error);
        }

        if (error.status !== 401) return throwError(error);

        if (!GetRefreshToken()) return throwError(error);

        if (this.refreshTokenInProgress) {
          return this.refreshTokenSubject.pipe(filter(result => result !== null),
            take(1),
            switchMap(() => next.handle(this.addAuthenticationToken(request))));
        } else {
          this.refreshTokenInProgress = true;
          this.refreshTokenSubject.next(null);
          return this.auth
            .SignInRefresh$({
              RefreshToken: GetRefreshToken()
            }).pipe(switchMap((token: SignInRefreshResponse) => {
                this.refreshTokenInProgress = false;
                this.refreshTokenSubject.next(token);
                if (!token.isSuccessful) this.authService.SignOut();
                else MemoryTimeCacheHelper.Set<string>(ACCESS_KEY, token.jwtAuthModel.AccessToken, Date.now() + ONE_WEEK_IN_SECONDS);

                return next.handle(this.addAuthenticationToken(request));
              }),
              catchError((err: any) => {
                this.authService.SignOut();
                this.refreshTokenInProgress = false;
                return throwError(err);
              }));
        }
      })
    );
  }

  addAuthenticationToken(request: any) {
    const accessToken = GetToken();
    if (!accessToken) return request;

    return request.clone({setHeaders: {Authorization: "Bearer " + GetToken()}});
  }
}
