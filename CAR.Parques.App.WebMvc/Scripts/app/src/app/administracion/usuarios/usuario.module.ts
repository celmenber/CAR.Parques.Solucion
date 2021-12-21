import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuarioRoutingModule } from './usuario-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material/material.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { NuevoUsuarioComponent } from './nuevo-usuario/nuevo-usuario.component';
import { EditarUsuarioComponent } from './editar-usuario/editar-usuario.component';
import { AdmUsuariosListComponent } from './adm-usuarios-list/adm-usuarios-list.component';
import { DetalleUsuarioComponent } from './detalle-usuario/detalle-usuario.component';



@NgModule({
  declarations: [AdmUsuariosListComponent ,NuevoUsuarioComponent, EditarUsuarioComponent, DetalleUsuarioComponent],
  imports: [
    CommonModule,
    UsuarioRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    SharedModule
  ],
  entryComponents:[NuevoUsuarioComponent, EditarUsuarioComponent]
})
export class UsuarioModule { }
