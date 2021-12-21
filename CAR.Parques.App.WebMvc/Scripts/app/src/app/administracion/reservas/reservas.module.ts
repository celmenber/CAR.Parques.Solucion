import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReservaListComponent } from './reserva-list/reserva-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material/material.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReservasRoutingModule } from './reservas-routing.module';
import { ComprobanteReservaComponent } from './comprobante-reserva/comprobante-reserva.component';

@NgModule({
  declarations: [ReservaListComponent, ComprobanteReservaComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReservasRoutingModule,
    ReactiveFormsModule,
    MaterialModule,
    SharedModule
  ]
})
export class ReservasAdmModule { }
