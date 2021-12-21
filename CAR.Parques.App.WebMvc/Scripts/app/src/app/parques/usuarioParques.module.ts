import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material/material.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ParquesListComponent } from './parques-list/parques-list.component';
import { NoticiaDetalleComponent } from './noticias/noticia-detalle/noticia-detalle.component';

@NgModule({
  declarations: [ParquesListComponent, NoticiaDetalleComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    SharedModule,
  ],
  entryComponents: [],
})
export class UsuarioParqueModule {}
