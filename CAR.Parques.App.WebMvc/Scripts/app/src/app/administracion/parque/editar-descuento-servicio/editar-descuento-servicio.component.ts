import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { tipoUsuario } from 'src/app/models/parametricos/tipoUsuario';
import { descuentoServicioParque } from 'src/app/models/parques/descuentoServicioParque';
import { TipoUsuarioService } from 'src/app/servicios/parametricos/tipoUsuario.service';
import { DescuentoServicioparqueService } from 'src/app/servicios/parques/descuentoServicioParque.service';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';

export interface DialogData {
  descuentoId:number;
}

@Component({
  selector: 'app-editar-descuento-servicio',
  templateUrl: './editar-descuento-servicio.component.html',
  styleUrls: ['./editar-descuento-servicio.component.scss']
})
export class EditarDescuentoServicioComponent implements OnInit {

  editarDescuentoServicioParqueForm: FormGroup;
  _tipoUsuario: tipoUsuario[] = [];
  descuentoTipoUsuario: descuentoServicioParque;

  constructor(private fb: FormBuilder,
    public dialogRef: MatDialogRef<EditarDescuentoServicioComponent>,
    private tipoUsuarioService: TipoUsuarioService,
    private descuentoService: DescuentoServicioparqueService,
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private appBase: NotificacionComponent
    ) { 
      this.consultaDescuentoservicioParqueDetalle(data.descuentoId);
    }

  ngOnInit(): void {
    this.construirEditarDescuentoServicioFormulario();
    this.obtenerTipoUsuarios();
  }

  construirEditarDescuentoServicioFormulario() : void {
    this.editarDescuentoServicioParqueForm = this.fb.group({
      TipoUsuarioId: new FormControl({value: '', disabled: true}),
      Descuento: ['', Validators.compose([Validators.required])]
    });
  }

  obtenerTipoUsuarios() : void {
    this.tipoUsuarioService.getTipoUsuario()
    .subscribe(response => {
      //console.log(response.Entidad.Entidad);
      this._tipoUsuario = response.Entidad.Entidad;
    });
  }

  consultaDescuentoservicioParqueDetalle(id: number) : void {
    console.log(id);
    this.descuentoService.consultarDescuentoTipousuario(id)
    .subscribe(response => {
      console.log(response.Entidad.Entidad);
      this.descuentoTipoUsuario = response.Entidad.Entidad;
      console.log(this.descuentoTipoUsuario);
      this.editarDescuentoServicioParqueForm.patchValue({
        TipoUsuarioId: this.descuentoTipoUsuario.TipoUsuarioId,
        Descuento: this.descuentoTipoUsuario.Descuento,
      });
    });
  }

  guardar() : void {
    if(this.editarDescuentoServicioParqueForm.dirty && this.editarDescuentoServicioParqueForm.valid) {
      const datos = Object.assign({}, this.descuentoTipoUsuario, this.editarDescuentoServicioParqueForm.value);
      //console.log(datos);
      this.descuentoService.actualizarDescuentoTipousuario(datos)
      .subscribe(response => {
        if(response.Codigo == 200 && response.Entidad.Entidad)
        {
          this.appBase.openSnackBar("Actualización correcta.","exito-notificacion");
        }
        else
        {
          this.appBase.openSnackBar("Registro fallido, intente nuevamente o comuniquese con el administrador del sistema.","error-notificacion");
        }
        this.dialogRef.close();
      });
    }
    else if (!this.editarDescuentoServicioParqueForm.dirty) {
      this.editarDescuentoServicioParqueForm.reset();
    }
  }
}
