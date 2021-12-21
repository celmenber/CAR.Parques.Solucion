import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { tipoDocumento } from 'src/app/models/parametricos/tipoDocumento';
import { usuario } from 'src/app/models/usuario/usuario';
import { TipodocumentoService } from 'src/app/servicios/parametricos/tipodocumento.service';
import { UsuarioService } from 'src/app/servicios/usuario/usuario.service';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';
import { espaciosBlancoValidator } from 'src/app/shared/validators/espaciosBlancoValidator';
import { SoloLetrasValidator } from 'src/app/shared/validators/SoloLetrasValidator';
import { SoloNumerosValidator } from 'src/app/shared/validators/SoloNumerosValidaror';

export interface DialogData {
  usuarioId: number;
}

@Component({
  selector: 'app-editar-usuario',
  templateUrl: './editar-usuario.component.html',
  styleUrls: ['./editar-usuario.component.scss']
})

export class EditarUsuarioComponent implements OnInit {

  editarUsuarioForm: FormGroup;
  usuario: usuario;
  _tipoDocumentos: tipoDocumento[] = [];

  constructor(@Inject(MAT_DIALOG_DATA) public data: DialogData,
    private fb: FormBuilder, 
    public dialogRef: MatDialogRef<EditarUsuarioComponent>,
    private tipoDocService: TipodocumentoService,
    private usuarioService: UsuarioService,
    private appBase: NotificacionComponent) { 
      this.usuarioDetalle(data.usuarioId);
    }

  ngOnInit(): void {
    this.buildRegistroForm();
  }

  obtenerTiposDocumentos(): void{
    this.tipoDocService.getTipoDocumentos()
    .subscribe(response => {
      this._tipoDocumentos = response.Entidad.Entidad;
    });
  }
  
  buildRegistroForm(): void {
    this.obtenerTiposDocumentos();
    this.editarUsuarioForm = this.fb.group({
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
    if(this.editarUsuarioForm.dirty && this.editarUsuarioForm.valid) {
      const datos = Object.assign({}, this.usuario, this.editarUsuarioForm.value);
      this.usuarioService.editarUsuario(datos)
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
    else if (!this.editarUsuarioForm.dirty) {
      this.editarUsuarioForm.reset();
    }
  }

  usuarioDetalle(id: number) : void {
    this.usuarioService.getUsuarioId(id)
    .subscribe(response => {
      this.usuario = response.Entidad;
      this.editarUsuarioForm.patchValue({
        tipoDocumentoId: this.usuario.TipoDocumentoId,
        documento: this.usuario.Documento,
        nombre1: this.usuario.Nombre1,
        nombre2: this.usuario.Nombre2,
        apellido1: this.usuario.Apellido1,
        apellido2: this.usuario.Apellido2,
        email: this.usuario.Email
      });
    });
  }

}
