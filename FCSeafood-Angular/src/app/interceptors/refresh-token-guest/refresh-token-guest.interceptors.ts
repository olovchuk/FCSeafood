import { Injectable } from "@angular/core";
import { HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { tokenGuest } from "@common-services/auth.service";

@Injectable({providedIn: 'root'})
export class RefreshTokenGuestInterceptors implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const token = tokenGuest();

    if (token) {
      const modifiedReq = req.clone({
        headers: req.headers.set('Authorization', `Bearer ${token}`)
      });

      return next.handle(modifiedReq);
    }

    return next.handle(req);
  }
}
