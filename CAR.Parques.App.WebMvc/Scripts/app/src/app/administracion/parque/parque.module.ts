import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaqueRoutingModule } from './paque-routing.module';
import { EditarParqueComponent } from './editar-parque/editar-parque.component';
import { NuevoParqueComponent } from './nuevo-parque/nuevo-parque.component';
import { DetalleParqueComponent } from './detalle-parque/detalle-parque.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material/material.module';
import { ParqueComponent } from './parque/parque.component';
import { FileUploadComponent } from 'src/app/shared/file-upload/file-upload.component';
import { ServiciosListComponent } from './servicios-list/servicios-list.component';
import { ArchivosListComponent } from './archivos-list/archivos-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { EditarServicioParqueComponent } from './editar-servicio-parque/editar-servicio-parque.component';
import { DetalleServicioParqueComponent } from './detalle-servicio-parque/detalle-servicio-parque.component';
import { NuevoArchivoComponent } from './nuevo-archivo/nuevo-archivo.component';
import { NuevoServicioParqueComponent } from './nuevo-servicio-parque/nuevo-servicio-parque.component';
import { NuevoDescuentoServicioComponent } from './nuevo-descuento-servicio/nuevo-descuento-servicio.component';
import { EditarDescuentoServicioComponent } from './editar-descuento-servicio/editar-descuento-servicio.component';

@NgModule({
  declarations: [ParqueComponent, NuevoParqueComponent, EditarParqueComponent, DetalleParqueComponent, FileUploadComponent, ServiciosListComponent, ArchivosListComponent, EditarServicioParqueComponent, DetalleServicioParqueComponent, NuevoArchivoComponent, NuevoServicioParqueComponent, NuevoDescuentoServicioComponent, EditarDescuentoServicioComponent],
  imports: [
    CommonModule,
    PaqueRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    SharedModule
  ],
  entryComponents: [NuevoParqueComponent, EditarParqueComponent, DetalleParqueComponent, FileUploadComponent, EditarServicioParqueComponent, DetalleServicioParqueComponent, NuevoServicioParqueComponent]
})
export class ParqueModule {}
