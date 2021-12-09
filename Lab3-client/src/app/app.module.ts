import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { IconsProviderModule } from './icons-provider.module';
import { ProductLayoutComponent } from './layout/product-layout.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import en from '@angular/common/locales/en';
import { registerLocaleData } from '@angular/common';
import { NZ_I18N, en_US } from 'ng-zorro-antd/i18n';
import { CustomInterceptor } from './core/http/custom-http.interseptor';

registerLocaleData(en);

@NgModule({
  declarations: [
    AppComponent,
    ProductLayoutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    IconsProviderModule,
    FormsModule,
    NzLayoutModule,
    NzMenuModule,
    BrowserAnimationsModule
  ],
  providers: [{ provide: NZ_I18N, useValue: en_US },
  { provide: HTTP_INTERCEPTORS, useClass: CustomInterceptor, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
