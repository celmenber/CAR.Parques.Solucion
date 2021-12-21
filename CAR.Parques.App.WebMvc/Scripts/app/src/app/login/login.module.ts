import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginRoutingModule } from './login.routing.module';
import { LoginComponent } from './login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegistroComponent } from '../usuario/registro/registro.component';
import { MaterialModule } from '../material/material.module';
import { OlvidoContraseniaComponent } from '../usuario/olvido-contrasenia/olvido-contrasenia.component';
import { RestablecerComponent } from '../usuario/restablecer/restablecer.component';


@NgModule({
  declarations: [LoginComponent, RegistroComponent, OlvidoContraseniaComponent, RestablecerComponent],
  imports: [
    CommonModule,
    LoginRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  entryComponents:[RegistroComponent, OlvidoContraseniaComponent]
})
export class LoginModule  {  }
