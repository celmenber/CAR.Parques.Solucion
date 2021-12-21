import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SoloNumerosValidator } from 'src/app/shared/validators/SoloNumerosValidaror';
import { SoloLetrasValidator } from 'src/app/shared/validators/SoloLetrasValidator';
import { TipoServicioService } from 'src/app/servicios/parametricos/tipo-servicio.service';
import { tipoServicio } from 'src/app/models/parametricos/tipoServicio';
import { ServicioList } from 'src/app/models/parques/servicioList';
import { ServicioparqueService } from 'src/app/servicios/parques/servicioparque.service';
import { EstadoServicioService } from 'src/app/servicios/parametricos/estado-servicio.service';
import { estadoServicio } from 'src/app/models/parametricos/estadoServicio';
import { servicioParque } from 'src/app/models/parques/servicioParque';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';

export interface DialogData {
  servicioId:number;
}

@Component({
  selector: 'app-editar-servicio-parque',
  templateUrl: './editar-servicio-parque.component.html',
  styleUrls: ['./editar-servicio-parque.component.scss'],
  providers: [ServicioparqueService, TipoServicioService, EstadoServicioService]
})
export class EditarServicioParqueComponent implements OnInit {

  editarServicioParqueForm: FormGroup;
  _servicioParque: servicioParque = new servicioParque;
  _tipoServicio: tipoServicio[] = [];
  _estadoServicio: estadoServicio[] = [];
  checked = false;
  servicioParque: ServicioList;

  constructor(public dialogRef: MatDialogRef<EditarServicioParqueComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private fb: FormBuilder,
    private tipoServicioService: TipoServicioService,
    private estadoSerivicioService: EstadoServicioService,
    private servicioParqueService: ServicioparqueService,
    private appBase: NotificacionComponent) {
      this.servicioParqueDetalle(data.servicioId);
   }

  ngOnInit(): void {
    this.obtenerTipoServicios();
    this.obtenerEstados();
    this.construirEditarServicioParqueFormulario();
  }

  construirEditarServicioParqueFormulario() : void {
    this.editarServicioParqueForm = this.fb.group({
      ServicioParqueId: new FormControl({value: '', disabled: true}),
      FechaCreacion: new FormControl({value: '', disabled: true}),
      UsuarioCreacionNombre: new FormControl({value: '', disabled: true}),
      DescripcionServicioParque: ['', [Validators.required]],
      ImpuestoServicio: ['', Validators.compose([Validators.required])],
      NombreServicioParque: ['', Validators.compose([Validators.required])],
      PrecioServicio: ['', Validators.compose([Validators.required])],
      TipoServicioId: ['', Validators.compose([Validators.required])],
      EstadoServicioId: ['', Validators.compose([Validators.required])]
    });
  }

  obtenerTipoServicios() : void {
    this.tipoServicioService.getTipoServicios()
    .subscribe(response => {
      console.log(response.Entidad.Entidad);
      this._tipoServicio = response.Entidad.Entidad;
    });
  }

  obtenerEstados() : void {
    this.estadoSerivicioService.getEstados()
    .subscribe(response => {
      console.log(response.Entidad.Entidad);
      this._estadoServicio = response.Entidad.Entidad;
    });
  }

  servicioParqueDetalle(id: number) : void {
    console.log(id);
    this.servicioParqueService.consultarServicioParqueDetalleXId(id)
    .subscribe(response => {
      console.log(response.Entidad.Entidad);
      this._servicioParque = response.Entidad.Entidad;
      console.log(this._servicioParque);
      this.editarServicioParqueForm.patchValue({
        DescripcionServicioParque: this._servicioParque.DescripcionServicioParque,
        EstadoServicioId: this._servicioParque.EstadoServicioId,
        FechaCreacion: this._servicioParque.FechaCreacion,
        ImpuestoServicio: this._servicioParque.ImpuestoServicio,
        NombreServicioParque: this._servicioParque.NombreServicioParque,
        PrecioServicio: this._servicioParque.PrecioServicio,
        ServicioParqueId: this._servicioParque.ServicioParqueId,
        TipoServicioId: this._servicioParque.TipoServicioId,
        UsuarioCreacionNombre: this._servicioParque.UsuarioCreacionNombre
      });
    });
  }

  guardar() : void {
    if(this.editarServicioParqueForm.dirty && this.editarServicioParqueForm.valid) {
      const datos = Object.assign({}, this._servicioParque, this.editarServicioParqueForm.value);
      console.log(datos);
      this.servicioParqueService.actualizarServicioParque(datos)
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
    else if (!this.editarServicioParqueForm.dirty) {
      this.editarServicioParqueForm.reset();
    }
  }
}
