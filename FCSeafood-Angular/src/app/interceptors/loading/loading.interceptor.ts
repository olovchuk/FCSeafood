import { Injectable } from "@angular/core";
import { finalize, Observable } from "rxjs";
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { LoadingStateService } from "@common-services/loading-state/loading-state.service";

@Injectable({providedIn: 'root'})
export class LoadingInterceptor implements HttpInterceptor {
  constructor(private loadingStateService: LoadingStateService) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.loadingStateService.show()
    return next.handle(request).pipe(finalize(() => this.loadingStateService.hide()));
  }
}
