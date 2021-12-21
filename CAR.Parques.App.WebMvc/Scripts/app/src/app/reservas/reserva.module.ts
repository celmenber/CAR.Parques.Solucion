import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material/material.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ComprobanteReservaComponent } from '../reservas/comprobante-reserva/comprobante-reserva.component';
import { HistorialReservasComponent } from './historial-reservas/historial-reservas.component';
import { ReservasPendientesComponent } from './reservas-pendientes/reservas-pendientes.component';


@NgModule({
  declarations: [
    HistorialReservasComponent,
    ReservasPendientesComponent,
    ComprobanteReservaComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    SharedModule,
  ],
  exports: [
    HistorialReservasComponent,
    ReservasPendientesComponent,
    ComprobanteReservaComponent,
  ],
})
export class ReservasModule {}