import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { tipoDocumento } from 'src/app/models/parametricos/tipoDocumento';
import { usuarioOlvido } from 'src/app/models/usuario/usuarioOlvido';
import { TipodocumentoService } from 'src/app/servicios/parametricos/tipodocumento.service';
import { UsuarioService } from 'src/app/servicios/usuario/usuario.service';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';
import { espaciosBlancoValidator } from 'src/app/shared/validators/espaciosBlancoValidator';
import { SoloNumerosValidator } from 'src/app/shared/validators/SoloNumerosValidaror';

@Component({
  selector: 'app-olvido-contrasenia',
  templateUrl: './olvido-contrasenia.component.html',
  styleUrls: ['./olvido-contrasenia.component.scss'],
  providers: [TipodocumentoService]
})
export class OlvidoContraseniaComponent implements OnInit {

  olvidoContraseniaForm: FormGroup;
  _tipoDocumentos: tipoDocumento[] = [];
  usuarioOlvido: usuarioOlvido;

  constructor(private fb: FormBuilder,
    public dialogRef: MatDialogRef<OlvidoContraseniaComponent>,
    private appBase: NotificacionComponent,
    private usuarioService: UsuarioService,
    private tipoDocService: TipodocumentoService) { }

  ngOnInit(): void {
    this.buildOlvidoContraseniaForm();
  }

  obtenerTiposDocumentos(): void {
    this.tipoDocService.getTipoDocumentos()
    .subscribe(response => {
      console.log(response);
      this._tipoDocumentos = response.Entidad.Entidad;
    });
  }

  buildOlvidoContraseniaForm(): void {
    this.obtenerTiposDocumentos();
    this.olvidoContraseniaForm = this.fb.group({
      tipoDocumentoId: ['', [Validators.required]],
      documento: ['', [Validators.required, espaciosBlancoValidator.noEspacios, SoloNumerosValidator.soloNumeros]],
      email: ['', Validators.compose([Validators.required, Validators.email])]
    });
  }

  enviar() : void{
    if(this.olvidoContraseniaForm.dirty && this.olvidoContraseniaForm.valid) {
      const datos = Object.assign({}, this.usuarioOlvido, this.olvidoContraseniaForm.value);
      this.usuarioService.olvidoContrasenia(datos)
      .subscribe(response => {
        //debugger;
        console.log(response);
        if(response.Codigo === 200 && response.Entidad.Codigo !== 0)
        {
          this.appBase.openSnackBar("Solicitud de enviada con exito.","exito-notificacion");
        }
        else
        {
          this.appBase.openSnackBar(response.Entidad.Descripcion,"error-notificacion"); 
        }
        this.dialogRef.close();
      });
    }
    else if (!this.olvidoContraseniaForm.dirty) {
      this.olvidoContraseniaForm.reset();
    }
  }
}
