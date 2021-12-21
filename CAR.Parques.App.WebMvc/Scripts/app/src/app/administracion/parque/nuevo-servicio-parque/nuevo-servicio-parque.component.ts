import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/auth/auth.service';
import { estadoServicio } from 'src/app/models/parametricos/estadoServicio';
import { tipoServicio } from 'src/app/models/parametricos/tipoServicio';
import { servicioParque } from 'src/app/models/parques/servicioParque';
import { EstadoServicioService } from 'src/app/servicios/parametricos/estado-servicio.service';
import { TipoServicioService } from 'src/app/servicios/parametricos/tipo-servicio.service';
import { ServicioparqueService } from 'src/app/servicios/parques/servicioparque.service';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';

export interface DialogData {
  parqueId:number;
}

@Component({
  selector: 'app-nuevo-servicio-parque',
  templateUrl: './nuevo-servicio-parque.component.html',
  styleUrls: ['./nuevo-servicio-parque.component.scss'],
  providers: [ServicioparqueService, TipoServicioService, EstadoServicioService]
})

export class NuevoServicioParqueComponent implements OnInit {

  nuevoServicioParqueForm: FormGroup;
  _tipoServicio: tipoServicio[] = [];
  _estadoServicio: estadoServicio[] = [];
  servicioParque: servicioParque;
  _authStatus = null;

  constructor(private fb: FormBuilder, 
    private servicioParqueService: ServicioparqueService,
    private tipoServicioService: TipoServicioService,
    private estadoSerivicioService: EstadoServicioService,
    private authService: AuthService,
    public dialogRef: MatDialogRef<NuevoServicioParqueComponent>,
    private appBase: NotificacionComponent,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
    ) { }

  ngOnInit(): void {
    this.construirEditarServicioParqueFormulario();
    this.obtenerTipoServicios();
    this.obtenerEstados();
    const jwt = this.authService.getToken();
    this._authStatus = this.authService.transformarToken(jwt);
  }

  construirEditarServicioParqueFormulario() : void {
    this.nuevoServicioParqueForm = this.fb.group({
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

  guardar() : void {
    if(this.nuevoServicioParqueForm.dirty && this.nuevoServicioParqueForm.valid) {
      const datos = Object.assign({}, this.servicioParque, this.nuevoServicioParqueForm.value);
      datos.CreadoPorUsuarioId = this._authStatus.primarysid;
      datos.parqueId = this.data.parqueId;
      console.log(datos);
      this.servicioParqueService.guardarServicioParque(datos)
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
    else if (!this.nuevoServicioParqueForm.dirty) {
      this.nuevoServicioParqueForm.reset();
    }
    else {
      this.appBase.openSnackBar("Inserción correcta.","info-notificacion");
    }
  }
}
