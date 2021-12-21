import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { tipoUsuario } from 'src/app/models/parametricos/tipoUsuario';
import { descuentoServicioParque } from 'src/app/models/parques/descuentoServicioParque';
import { TipoUsuarioService } from 'src/app/servicios/parametricos/tipoUsuario.service';
import { DescuentoServicioparqueService } from 'src/app/servicios/parques/descuentoServicioParque.service';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';

export interface DialogData {
  servicioId:number;
}

@Component({
  selector: 'app-nuevo-descuento-servicio',
  templateUrl: './nuevo-descuento-servicio.component.html',
  styleUrls: ['./nuevo-descuento-servicio.component.scss']
})
export class NuevoDescuentoServicioComponent implements OnInit {

  nuevoDescuentoServicioParqueForm: FormGroup;
  _tipoUsuario: tipoUsuario[] = [];
  descuentoTipoUsuario: descuentoServicioParque;
  constructor(private fb: FormBuilder,
    public dialogRef: MatDialogRef<NuevoDescuentoServicioComponent>,
    private tipoUsuarioService: TipoUsuarioService,
    private descuentoService: DescuentoServicioparqueService,
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private appBase: NotificacionComponent
    ) { }

  ngOnInit(): void {
    this.construirNuevoDescuentoServicioFormulario();
    this.obtenerTipoUsuarios();
  }

  construirNuevoDescuentoServicioFormulario() : void {
    this.nuevoDescuentoServicioParqueForm = this.fb.group({
      TipoUsuarioId: ['', [Validators.required]],
      Descuento: ['', Validators.compose([Validators.required])]
    });
  }

  obtenerTipoUsuarios() : void {
    this.tipoUsuarioService.getTipoUsuario()
    .subscribe(response => {
      console.log(response.Entidad.Entidad);
      this._tipoUsuario = response.Entidad.Entidad;
    });
  }

  guardar() : void {
    if(this.nuevoDescuentoServicioParqueForm.dirty && this.nuevoDescuentoServicioParqueForm.valid) {
      const datos = Object.assign({}, this.descuentoTipoUsuario, this.nuevoDescuentoServicioParqueForm.value);
      datos.servicioId = this.data.servicioId;
      console.log(datos);
      this.descuentoService.guardarDescuentoTipousuario(datos)
      .subscribe(response => {
        console.log(response.Entidad.Entidad);
        if(response.Codigo == 200 && response.Entidad.Entidad !== 0)
        {
          this.appBase.openSnackBar("Registro servicio exitoso.","success-notificacion");
        }
        else
        {
          this.appBase.openSnackBar("Registro fallido, intente nuevamente o comuniquese con el administrador del sistema.","error-notificacion");
        }
        this.dialogRef.close();
      });
    }
    else if (!this.nuevoDescuentoServicioParqueForm.dirty) {
      this.nuevoDescuentoServicioParqueForm.reset();
    }
    else {
      this.appBase.openSnackBar("Inserción correcta.","info-notificacion");
    }
  }
}
