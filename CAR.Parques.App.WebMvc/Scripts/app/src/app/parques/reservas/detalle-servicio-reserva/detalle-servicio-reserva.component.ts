import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { servicioParque } from 'src/app/models/parques/servicioParque';
import { ServicioparqueService } from 'src/app/servicios/parques/servicioparque.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MY_DATE_FORMATS } from 'src/app/common/my-date-formats';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import * as moment from 'moment';
import { detalleReserva } from 'src/app/models/reservas/detalleReserva';
import { ReservaService } from 'src/app/servicios/reservas/reservas.service';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';
import { AuthService } from 'src/app/auth/auth.service';

export interface DialogData {
  servicioId:number;
  color:string;
}

@Component({
  selector: 'app-detalle-servicio-reserva',
  templateUrl: './detalle-servicio-reserva.component.html',
  styleUrls: ['./detalle-servicio-reserva.component.scss'],
  providers: [
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS }]
})
export class DetalleServicioReservaComponent implements OnInit {
  userAuthenticated:boolean = false;
  _servicioParque: servicioParque = new servicioParque();
  minDate: Date;
  maxDate: Date;
  colorParque: string;
  objetoServicios: object[] = [];
  ServicioReservaForm: FormGroup;
  validadorForm: boolean;
  //cantidad: number = 0;
  //formatoFecha: string;

  constructor(private servicioParqueService: ServicioparqueService,
    private reservasService: ReservaService,
    private fb: FormBuilder,
    private appBase: NotificacionComponent,
    private dialogRef: MatDialogRef<DetalleServicioReservaComponent>,
    private authService: AuthService, 
    @Inject(MAT_DIALOG_DATA) public data: DialogData) { 
    this.servicioParqueDetalle(data.servicioId);
    const currentYear = new Date().getFullYear();
    const Day = new Date().getDate();
    const Month = new Date().getMonth();
    this.minDate = new Date(currentYear, Month, Day);
    this.maxDate = new Date(currentYear, 11, 31);
    this.colorParque = data.color;
    this.validadorForm = true;
    //this.formatoFecha = 'DD-MM-YYYY';
  }

  ngOnInit(): void {
    this.construirReservaFormulario();
    this.isUserAuthenticated();
  }

  isUserAuthenticated(): void
  {
    const jwt = this.authService.getToken();
    var infoToken = (jwt !== null && jwt !== '') ? this.authService.transformarToken(jwt) : '';
    this.userAuthenticated = (infoToken !== null && infoToken !== '') ? true : false;
    console.log(this.userAuthenticated);
  }

  construirReservaFormulario() : void {
    this.ServicioReservaForm = this.fb.group(
    {            
      FechaInicio: new FormControl(),
      FechaFin: new FormControl(),
      FechaReserva: new FormControl(),
      cantidad: new FormControl()
    },
    { validator: this.checkDates }
    );
  }

  checkDates(group: FormGroup) {
    console.log(group.controls.FechaInicio.value);
    console.log(group.controls.FechaFin.value);
    if ((group.controls.FechaInicio.value != null && group.controls.FechaFin.value != null) || group.controls.FechaReserva.value != null){
      let formatoFecha = 'DD-MM-YYYY';
      if (
        moment(group.controls.FechaFin.value, formatoFecha) <=
        moment(group.controls.FechaInicio.value, formatoFecha)      
      ) {   
        //console.log('Entro validacion');
        return { notValid: true, errorRange: true, validacionFecha: true };      
      }
      //console.log('NO Entro validacion');
      return { notValid: false, errorRange: false };
    }
    else
    {
      return { notValid: true, errorRange: true };      
    }
    
  }

  ValidarDatosFormulario(group: FormGroup) {
    if ((group.controls.FechaInicio.value != 'NA' && group.controls.FechaFin.value != 'NA') || group.controls.FechaReserva.value != 'NA')
    {
        this.validadorForm = false;
    }
    else{
      this.validadorForm = true;
    }
  }

  servicioParqueDetalle(id: number) : void {
    this.servicioParqueService.consultarServicioParqueDetalleXId(id)
    .subscribe(response => {
      console.log(response.Entidad.Entidad);
      this._servicioParque = response.Entidad.Entidad;
    });
  }

  formatearFecha(fecha): string {       
    let momentVariable = moment(fecha,'DD-MM-YYYY');
    let stringvalue = momentVariable.format('DD-MM-YYYY');
    return stringvalue;
  }

  anadirServicio(): void{   
    
    var _detalleReserva: detalleReserva = new detalleReserva();
    var FormDetalleReser = this.ServicioReservaForm.value;

    _detalleReserva.NombreServicio = this._servicioParque.NombreServicioParque;
    _detalleReserva.ServicioId = this._servicioParque.ServicioParqueId;
    

    _detalleReserva.FechaInicio = (FormDetalleReser.FechaInicio !== null && FormDetalleReser.FechaInicio !== 'NA') ? FormDetalleReser.FechaInicio.format('DD/MM/YYYY') : 'NA';    
    _detalleReserva.FechaFin = (FormDetalleReser.FechaFin !== null && FormDetalleReser.FechaFin !== 'NA') ? FormDetalleReser.FechaFin.format('DD/MM/YYYY') : 'NA';
      if (FormDetalleReser.FechaReserva !== null  && FormDetalleReser.FechaReserva != 'NA') {       
      _detalleReserva.FechaFin = FormDetalleReser.FechaReserva.format('DD/MM/YYYY');
      }
    _detalleReserva.PrecioTotalServicio = this._servicioParque.PrecioServicio;
    _detalleReserva.PrecioTotalDescuento = this._servicioParque.PrecioServicio;
    _detalleReserva.Cantidad = FormDetalleReser.cantidad == null ? 1 : FormDetalleReser.cantidad;    

    let momentVariable = moment(new Date(),'DDMMYYYY');
    let stringvalue = momentVariable.format('DD/MM/YYYY');
    _detalleReserva.FechaInicio = stringvalue;
  
    // let momentFechaFin = moment(
    //   noticia.FechaFinVigencia,
    //   formatoFecha
    // ).toDate();

    //_detalleReserva.FechaInicio = new Date(_detalleReserva.FechaInicio).toLocaleDateString();
    //_detalleReserva.FechaFin = new Date(_detalleReserva.FechaFin).toLocaleDateString();

    console.log('antes de ir al servicio');
    console.log(this.ServicioReservaForm.value);

    this.reservasService.ValidarPreReserva(_detalleReserva)
        .subscribe(response => {
        console.log(response.Entidad.Entidad);
        if(response.Codigo == 200)
        {
          this.appBase.openSnackBar("Se añadio el servicio.", "exito-notificacion");
        }
        else
        {
          this.appBase.openSnackBar("Falla en la validación de la pre-reserva, intente nuevamente o comuniquese con el administrador del sistema.","error-notificacion");
        }
      });
    
    console.log(this.ServicioReservaForm.value);
     var filtro = this.ServicioReservaForm.value;
    filtro.FechaInicio = (filtro.FechaInicio !== null && filtro.FechaInicio !== 'NA') ? filtro.FechaInicio.format('DD/MM/YYYY') : 'NA';
    filtro.FechaFin = (filtro.FechaFin !== null && filtro.FechaFin !== 'NA') ? filtro.FechaFin.format('DD/MM/YYYY') : 'NA';
    filtro.FechaReserva = (filtro.FechaReserva !== null && filtro.FechaReserva !== 'NA') ? filtro.FechaReserva.format('DD/MM/YYYY') : 'NA';
    console.log('valor cantidad');
    console.log(filtro.cantidad);
    //filtro.cantidad = (filtro.cantidad !== null) ? filtro.cantidad : 1;
    this.dialogRef.close({data: Object.assign(this._servicioParque,{datafInicio: filtro.FechaInicio , 
    datafF: filtro.FechaFin, datafReser: filtro.FechaReserva, dataCantidad: filtro.cantidad })});
    // this.dialogRef.close({data: Object.assign(this._servicioParque,{datafInicio: filtro.FechaInicio , 
    //   datafF: filtro.FechaFin, datafReser: filtro.FechaReserva })});  
  }
}
