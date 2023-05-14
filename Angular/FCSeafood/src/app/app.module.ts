import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {MaterialModule} from "@modules/material/material.module";
import {FooterComponent} from '@modules/components/footer/footer.component';
import {HeaderComponent} from '@modules/components/header/header.component';
import {JwtModule} from "@auth0/angular-jwt";
import {GetToken} from "@common-services/auth/auth.service";
import {AppSettings} from "@settings/app.settings";
import {RefreshTokenInterceptor} from "@interceptors/refresh-token.interceptor/refresh-token.interceptor";
import {PopupsComponentsModule} from "@modules/components/popups/popups-components.module";
import {NgOptimizedImage} from "@angular/common";
import {MainMenuItemComponent} from '@modules/components/header/main-menu/main-menu-item/main-menu-item.component';
import {MainMenuComponent} from '@modules/components/header/main-menu/main-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    MainMenuItemComponent,
    MainMenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    PopupsComponentsModule,
    NgOptimizedImage,
    JwtModule.forRoot({
      config: {
        tokenGetter: GetToken,
        allowedDomains: AppSettings.allowedDomainsJWT,
        disallowedRoutes: [],
        skipWhenExpired: true
      },
    }),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: RefreshTokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
