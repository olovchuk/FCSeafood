import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { HeaderComponent } from "@modules-components/header/header.component";
import { FooterComponent } from "@modules-components/footer/footer.component";
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from "./app-routing.module";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { PrimengModule } from "@modules/primeng/primeng.module";
import { MaterialModule } from "@modules/material/material.module";
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { PopupsModule } from "@modules-components/popups/popups.module";
import { NgOptimizedImage } from "@angular/common";
import { JwtModule } from "@auth0/angular-jwt";
import { token } from "@common-services/auth.service";
import { AppSettings } from "@settings/app.settings";
import { RefreshTokenInterceptor } from "@interceptors/refresh-token/refresh-token.interceptor";
import { RefreshTokenGuestInterceptors } from "@interceptors/refresh-token-guest/refresh-token-guest.interceptors";

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    PrimengModule,
    MaterialModule,
    HttpClientModule,
    PopupsModule,
    NgOptimizedImage,
    JwtModule.forRoot({
      config: {
        tokenGetter: token,
        allowedDomains: AppSettings.allowedDomainsJWT,
        disallowedRoutes: [],
        skipWhenExpired: true
      },
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: RefreshTokenInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: RefreshTokenGuestInterceptors,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
