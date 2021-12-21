import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { MaterialModule } from './material/material.module';
import { HomeModule } from './home/home.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LogoutComponent } from './logout/logout.component';
import { AuthService } from './auth/auth.service';
import { AuthGuard } from './auth/auth.guard';
import { AuthHttpInterceptor } from './auth/AuthHttpInterceptor';
import { CargadorService } from './servicios/shared/cargador.service';
import { RouterModule, Router } from '@angular/router';
import { ReservasModule } from './reservas/reserva.module';
import { RestablecerComponent } from './usuario/restablecer/restablecer.component';
// import { HashLocationStrategy, LocationStrategy } from '@angular/common';

@NgModule({
  declarations: [AppComponent, LogoutComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule,
    AppRoutingModule,
    SharedModule, 
    HttpClientModule,
    HomeModule,
    MaterialModule,
    ReservasModule
    //NgbModule,    
  ],
  providers: [
    AuthService,
    AuthGuard,
    CargadorService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthHttpInterceptor,
      multi: true,
    }
    // ,
    // {
    //   provide: LocationStrategy, useClass: HashLocationStrategy
    // }
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
