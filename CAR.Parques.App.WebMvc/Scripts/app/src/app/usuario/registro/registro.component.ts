import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { UsuarioService } from 'src/app/servicios/usuario/usuario.service';
import { TipodocumentoService } from 'src/app/servicios/parametricos/tipodocumento.service';
import { usuario } from 'src/app/models/usuario/usuario';
import { tipoDocumento } from 'src/app/models/parametricos/tipoDocumento';
import { espaciosBlancoValidator } from 'src/app/shared/validators/espaciosBlancoValidator';
import { SoloNumerosValidator } from 'src/app/shared/validators/SoloNumerosValidaror';
import { SoloLetrasValidator } from 'src/app/shared/validators/SoloLetrasValidator';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.scss'],
  providers: [UsuarioService, TipodocumentoService]
})
export class RegistroComponent implements OnInit {

  nuevoUsuarioForm: FormGroup;
  usuario: usuario;
  _tipoDocumentos: tipoDocumento[] = [];

  constructor(private fb: FormBuilder, 
    public dialogRef: MatDialogRef<RegistroComponent>,
    private tipoDocService: TipodocumentoService,
    private usuarioService: UsuarioService,
    private appBase: NotificacionComponent) { }

  ngOnInit(): void {
    this.buildRegistroForm();
  }

  obtenerTiposDocumentos(): void {
    this.tipoDocService.getTipoDocumentos()
    .subscribe(response => {
      this._tipoDocumentos = response.Entidad.Entidad;
    });
  }

  buildRegistroForm(): void {
    this.obtenerTiposDocumentos();
    this.nuevoUsuarioForm = this.fb.group({
      tipoDocumentoId: ['', [Validators.required]],
      documento: ['', [Validators.required, espaciosBlancoValidator.noEspacios, SoloNumerosValidator.soloNumeros]],
      nombre1: ['', Validators.compose([Validators.required, espaciosBlancoValidator.noEspacios, SoloLetrasValidator.soloLetras])],
      nombre2: ['', Validators.compose([espaciosBlancoValidator.noEspacios, SoloLetrasValidator.soloLetras])],
      apellido1: ['', Validators.compose([Validators.required, espaciosBlancoValidator.noEspacios, SoloLetrasValidator.soloLetras])],
      apellido2: ['', Validators.compose([espaciosBlancoValidator.noEspacios, SoloLetrasValidator.soloLetras])],
      email: ['', Validators.compose([Validators.required, Validators.email])],
      passwordUsuario: ['', Validators.compose([Validators.required, espaciosBlancoValidator.noEspacios])],
      passwordUsuarioConfirma: ['']
    },{validator: this.confirmarCoincidenciaContrasenia });
  }

  confirmarCoincidenciaContrasenia(group: FormGroup) {
      let passwordInput = group.get('passwordUsuario').value;
      let passwordConfirmationInput = group.controls['passwordUsuarioConfirma'];
      console.log(passwordInput === passwordConfirmationInput.value);
      if(passwordInput !== passwordConfirmationInput.value)
      {
        return passwordConfirmationInput.setErrors({notEquivalent: true});
      }
      return passwordConfirmationInput.setErrors(null);
  }

  guardar(): void{
    if(this.nuevoUsuarioForm.dirty && this.nuevoUsuarioForm.valid) {
      const datos = Object.assign({}, this.usuario, this.nuevoUsuarioForm.value);
      this.usuarioService.guardarUsuario(datos)
      .subscribe(response => {
        if(response.Codigo === 200 && response.Entidad.Entidad !== 0)
        {
          this.appBase.openSnackBar("Registro exitoso.","exito-notificacion");
        }
        else
        {
          this.appBase.openSnackBar("Registro fallido, intente nuevamente o comuniquese con el administrador del sistema.","error-notificacion"); 
        }
        this.dialogRef.close();
      });
    }
    else if (!this.nuevoUsuarioForm.dirty) {
      this.nuevoUsuarioForm.reset();
    }
  }
}
