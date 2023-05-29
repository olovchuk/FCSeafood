import { Injectable } from "@angular/core";
import { ACCESS_KEY, AuthService, refreshToken, token, ONE_WEEK_IN_SECONDS } from "@common-services/auth.service";
import { BehaviorSubject, catchError, filter, Observable, switchMap, take, throwError } from "rxjs";
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { AuthData } from "@common-data/auth/auth.data";
import { MemoryTimeCacheHelper } from "@common-helpers/memory-time-cache.helper";
import { SignInRefreshResponse } from "@common-data/auth/http/response/sign-in-refresh.response";

@Injectable({providedIn: 'root'})
export class RefreshTokenInterceptor implements HttpInterceptor {
  private refreshTokenInProgress = false;

  private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);

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
          this.authService.signOut();
          return throwError(error);
        }

        if (error.status !== 401) return throwError(error);

        if (!refreshToken()) return throwError(error);

        if (this.refreshTokenInProgress) {
          return this.refreshTokenSubject.pipe(filter(result => result !== null),
            take(1),
            switchMap(() => next.handle(this.addAuthenticationToken(request))));
        }
        else {
          this.refreshTokenInProgress = true;
          this.refreshTokenSubject.next(null);
          return this.auth.signInRefresh$({
            RefreshToken: refreshToken()
          }).pipe(switchMap((token: SignInRefreshResponse) => {
              this.refreshTokenInProgress = false;
              this.refreshTokenSubject.next(token);
              if (!token.isSuccessful) this.authService.signOut();
              else MemoryTimeCacheHelper.Set<string>(ACCESS_KEY, token.jwtAuthModel.accessToken, Date.now() + ONE_WEEK_IN_SECONDS);

              return next.handle(this.addAuthenticationToken(request));
            }),
            catchError((err: any) => {
              this.authService.signOut();
              this.refreshTokenInProgress = false;
              return throwError(err);
            }));
        }
      })
    );
  }

  addAuthenticationToken(request: any) {
    const _token = token();
    if (!_token) return request;

    return request.clone({setHeaders: {Authorization: "Bearer " + _token}});
  }
}
