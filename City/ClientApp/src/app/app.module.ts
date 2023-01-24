import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { InjectionToken, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

export const API_BASE_URL = new InjectionToken<string>('');

@NgModule({
  declarations: [
    AppComponent, NavMenuComponent, HomeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    // BrowserModule,
    AppRoutingModule,
    ApiAuthorizationModule,
    HttpClientModule,
    BrowserAnimationsModule,
  ],
  providers: [
    // {
    //   provide: API_BASE_URL,
    //   useValue: 'https://localhost:7272'
    // },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthorizeInterceptor, multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
