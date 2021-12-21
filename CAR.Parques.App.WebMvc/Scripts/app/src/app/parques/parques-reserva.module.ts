import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material/material.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ParquesListComponent } from './parques-list/parques-list.component';
import { ReservasComponent } from './reservas/reservas.component';
import { PaqueReservaRoutingModule } from './parques-reserva-routing.module';
import { GaleriareservasComponent } from './reservas/galeriareservas/galeriareservas.component';
import { InformacionParqueComponent } from './informacion-parque/informacion-parque.component';
import { UrlSeguraPipe } from 'src/app/pipes/UrlSegura/urlSegura-pipe';
import { HtmlSeguroPipe } from '../pipes/HtmlSeguro/htmlSeguro-pipe';
import { DetalleServicioReservaComponent } from './reservas/detalle-servicio-reserva/detalle-servicio-reserva.component';

@NgModule({
  declarations: [
    ParquesListComponent,
    ReservasComponent,
    GaleriareservasComponent,
    InformacionParqueComponent,
    UrlSeguraPipe,
    HtmlSeguroPipe,
    DetalleServicioReservaComponent
  ],
  imports: [
    CommonModule,
    PaqueReservaRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    SharedModule,
  ],
  entryComponents: [GaleriareservasComponent],
})
export class ParqueReservasModule {}
