import { Component, OnInit,ViewChild, AfterViewInit, ChangeDetectorRef , TemplateRef} from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from  '@angular/material/dialog';
import { ArchivoparqueService } from 'src/app/servicios/parques/archivoparque.service';
//import { archivoParque } from 'src/app/models/parques/archivoParque';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ServicioparqueService} from 'src/app/servicios/parques/servicioparque.service'
import { ParqueService } from 'src/app/servicios/parques/parque.service';
import { parque } from 'src/app/models/parques/parque';
import { GaleriareservasComponent } from 'src/app/parques/reservas/galeriareservas/galeriareservas.component'
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MY_DATE_FORMATS } from 'src/app/common/my-date-formats';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { ReservaService } from 'src/app/servicios/reservas/reservas.service';
import { Reservas } from 'src/app/models/Reserva/reservas';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';
import { servicioParque } from 'src/app/models/parques/servicioParque'
import { GrillaComponent } from 'src/app/shared/grilla/grilla.component';
import { DetalleServicioReservaComponent } from 'src/app/parques/reservas/detalle-servicio-reserva/detalle-servicio-reserva.component';
import * as moment from 'moment';
import { detalleReserva } from 'src/app/models/reservas/detalleReserva';
import { DetalleReserva } from 'src/app/models/Reserva/detalleReserva';
import { DomSanitizer } from '@angular/platform-browser';
import { AuthService } from 'src/app/auth/auth.service';
// import {MatSort} from '@angular/material/sort';
// import {AfterViewInit, ViewChild} from '@angular/core';

@Component({
  selector: 'app-reservas',
  templateUrl: './reservas.component.html',
  styleUrls: ['./reservas.component.scss'],
  providers: [
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS }]
})
export class ReservasComponent implements OnInit {
  userAuthenticated:boolean = false;
  parqueId: number = 0;
  imagenesGaleria: any[] = [];
  archivosPdf: any[] = [];
  Imgprincipal: any;
  servicios: Object[] = [];
  ReservaForm: FormGroup;
  _parque: parque = new parque();
  minDate: Date;
  maxDate: Date;
  //lunes: number;
  //Cambio del object a DetalleReserva
  //objreservas: object[] = [];
  objreservas: DetalleReserva[] = [];
  objFilterreservas: object[] = [];
  _reserva: Reservas = new Reservas();
  _DetalleReserva: DetalleReserva = new DetalleReserva();
  total: number = 0;
  medioPago: number = 0;
  estadoReservaPendiente: number = 2;

  //objetos: object[] = [];

  public mobile: boolean;
  items: Object[] = [];
  listadorservicioDetalle: servicioParque[] = [];
  ArrayReserva: object[] = [];
  public columns: object[] = [];
  public detailColumns:  Object[] = [];
  @ViewChild("tableView") tableView: GrillaComponent<any>;
  @ViewChild("AccionesTemplate") private accionesTemplate: TemplateRef<any>;
  @ViewChild("DescripcionTemplate") private descripcionTemplate: TemplateRef<any>;
  @ViewChild("servicioIdTemplate") private servicioIdTemplate: TemplateRef<any>;
  

  constructor( 
    private sanitizer: DomSanitizer,
    private archivoParqueService: ArchivoparqueService,
    private fb: FormBuilder,
    private parqueService: ParqueService,
    private serviciosparqueService: ServicioparqueService,
    private reservasService: ReservaService,
    public dialog: MatDialog,
    private route: ActivatedRoute,
    private appBase: NotificacionComponent,
    private ref: ChangeDetectorRef,
    private authService: AuthService
    ) { const currentYear = new Date().getFullYear();
    const Day = new Date().getDate();
    const Month = new Date().getMonth();
    this.minDate = new Date(currentYear, Month, Day);
    this.maxDate = new Date(currentYear, 11, 31); }

  ngOnInit(): void {
    
    this.parqueId = parseInt(this.route.snapshot.params['id']);
    this.obtenerParque(this.parqueId);
    this.consultarArchivosParque(this.parqueId);
    this.obtenerServiciosParque(this.parqueId);
    this.isUserAuthenticated();

    if (window.screen.width <= 768) {
      this.mobile = true;
    }
    else {
      this.mobile = false;
    }

    
    //this.construirReservaFormulario();

    //this.columns = this.getColumns();
  }

  isUserAuthenticated(): void
  {
    const jwt = this.authService.getToken();
    var infoToken = (jwt !== null && jwt !== '') ? this.authService.transformarToken(jwt) : '';
    this.userAuthenticated = (infoToken !== null && infoToken !== '') ? true : false;    
  }

  ngAfterViewInit() : void {
    this.columns = this.getColumns();
    this.ref.detectChanges();
  }

  sanitize(url: string) {
    return this.sanitizer.bypassSecurityTrustUrl(url);
  }
  // construirReservaFormulario() : void {
  //   this.ReservaForm = this.fb.group({
  //     FechaInicio: new FormControl(),
  //     FechaFin: new FormControl()
  //   },
  //   { validator: this.checkDates }
  //   );
  // }

  // checkDates(group: FormGroup) {
  //   let formatoFecha = 'DD-MM-YYYY';
  //   if (
  //     moment(group.controls.fechaFinVigencia.value, formatoFecha) <
  //     moment(group.controls.fechaInicioVigencia.value, formatoFecha)
  //   ) {
  //     return { notValid: true, errorRange: true };
  //   }
  //   return null;
  // }

  
  // Filtrolunes = (d: Date | null): boolean => {
  //   const day = (d = new Date()).getDay();      
  //   //const lun = (d || new Date()).getDay();   
  //   console.log('Test ' + d);    
  //   console.log('Lunes ' + lun);    
  //   //console.log('Lunesday' + day);
  //   return lun !== 1;

  //   //const lun = (d || new Date()).getDay();    
  //   //return lun !== 1;
  // }

  consultarArchivosParque(parqueId: number): void {
          this.archivoParqueService.consultarArchivosParque(1,parqueId)
          .subscribe(
            response => {
              var objetoArchivosPr = response.Entidad.Entidad[0];              
                if(objetoArchivosPr!== undefined)
                {
                   var bytes = objetoArchivosPr.ByteArchivo;
                   var url = 'data:image/jpeg;base64,' + bytes;
                  this.Imgprincipal = url;                 
                }
            }
          );
          //this.archivoParqueService.obtenerArchivosParque(parqueId)
          this.archivoParqueService.obtenerArchivosParque(parqueId).subscribe(
          response2 => {
            var objetoArchivosGnral = response2.Entidad.Entidad;
            if(objetoArchivosGnral!== undefined && objetoArchivosGnral.length>0)
            {
                  this.archivosPdf = objetoArchivosGnral.filter(function (obj) { return obj.TipoArchivoId == 2 });
                  console.log('this.archivosPdf');
                  console.log(this.archivosPdf);
                  this.imagenesGaleria = objetoArchivosGnral.filter(function (obj) { return obj.TipoArchivoId == 3});                  
                  // console.log(objetoArchivosGnral);
                  // console.log('Archivo');
                  // console.log(objetoArchivosGnral);
                  // console.log(this.imagenesGaleria);                  
                for (let archivo of this.imagenesGaleria) 
                {
                  var bytes = archivo.ByteArchivo;
                  var url = 'data:image/jpeg;base64,' + bytes;
                  // console.log('RutaArchivoParque');
                  // console.log(archivo);
                  // console.log(archivo.RutaArchivoParque);
                  archivo.RutaArchivoParque = url;                 
                }

                for (let archivo of this.archivosPdf) {
                  var bytes = archivo.ByteArchivo;
                  let url = 'data:application/pdf;base64,' + bytes;
                  archivo.rutaArchivoParque = url;
                }
            }
          }
          );
        }

obtenerServiciosParque(parqueId: number): void {
  this.serviciosparqueService.consultarServiciosParque(parqueId)
  .subscribe(response => {
    //this.servicios = response.Entidad.Entidad;
    this.listadorservicioDetalle = response.Entidad.Entidad;    
    console.log('servicios'); 
    console.log(response.Entidad.Entidad);    
  });
}

private getColumns(): object[] {
    let listadoColumnasMobile : Object[] = [
      {
        name: "",
        flexGrow: this.mobile !== true ? 0.06 : 0.1,
        cellTemplate: this.servicioIdTemplate
      },    
      {
        name:"Detalle Reserva",
        flexGrow: 0.4,
        cellTemplate: this.accionesTemplate,
      },
      {
        name: "Servicio",
        prop: "NombreServicioParque",
        flexGrow: 0.5,
        sortable: true
      },
      {
        name: "Precio",
        prop : "PrecioServicio",
        flexGrow: 0.3,
        sortable: true,
      },
      {
        name: "Fecha Reserva",
        prop : "datafReser",
        flexGrow: 0.3,
        sortable: true
      },
    ];

    let listadoColumnasEscritorio: Object[] = [
      {
        name: "Descripción",
        prop: "DescripcionServicioParque",
        flexGrow: 1,
        cellTemplate: this.descripcionTemplate
      },     
    ];

    let listadoConsolidado : Object[] = [];
    if(this.mobile === false) {
      listadoConsolidado = listadoColumnasMobile.concat(listadoColumnasEscritorio);
    }
    else {
      listadoConsolidado = listadoColumnasMobile;
    }
    return listadoConsolidado;
  }

toggleExpandRow(row:any) : void {
  this.tableView.toggleExpandRow(row);
  this.ref.detectChanges();
}


// private AnadirServiciosReserva(): void {   

//     this.objFilterreservas = this.objreservas;    
//     //this.ngAfterViewInit();
//   }

  eliminarDetalleReserva(index : number): void{
  this.objreservas.splice(index, 1);
  this.calcularTotalReserva();
  }

  calcularTotalReserva(): void{
    this.total = 0;

    for (let i = 0; i < this.objreservas.length; i++) {
      let element = this.objreservas[i];
      this.total += element["PrecioTotalDescuento"] * element["Cantidad"];
      
    }
    }

    formatearFecha(fecha): string {       
      let momentVariable = moment(fecha,'DD-MM-YYYY');
      let stringvalue = momentVariable.format('DD-MM-YYYY');
      return stringvalue;
    }

verServicioParque(servicioId: number, color:string) : void {
  let dialogRef = this.dialog.open(DetalleServicioReservaComponent, {
    panelClass: "detalle-parque-modal-dialog",
    data: {servicioId: servicioId,
          color: color}
  });
  dialogRef.afterClosed().subscribe(result => {
    if ((result.data.FechaInicio != 'NA' && result.data.FechaFin != 'NA') || result.data.FechaReserva != 'NA'){
      var _detalleReserva: detalleReserva = new detalleReserva();
      _detalleReserva.NombreServicio = result.data.NombreServicioParque;
      _detalleReserva.ServicioId = result.data.ServicioParqueId;
      _detalleReserva.FechaInicio = result.data.datafReser!= 'NA' ? result.data.datafReser : result.data.datafInicio;
      _detalleReserva.FechaFin = result.data.datafReser!= 'NA' ? result.data.datafReser : result.data.datafF;      
      _detalleReserva.PrecioTotalServicio = result.data.PrecioServicio;
      _detalleReserva.PrecioTotalDescuento = result.data.PrecioServicio;
      _detalleReserva.Cantidad = result.data.dataCantidad == null ? 1 : result.data.dataCantidad;
      //this.objreservas.push(result.data);
      console.log(result.data);
      console.log(_detalleReserva);
      this.objreservas.push(_detalleReserva);
      // console.log(this.objreservas);
      this.calcularTotalReserva();
    }
    // var objreservasMemento =  Object.assign([] ,this.objreservas); 
    // objreservasMemento.push(result.data);
    // this.objreservas = [];
    // Object.assign(this.objreservas , objreservasMemento); 
    //this.ref.detectChanges();
    //this.AnadirServiciosReserva();
  });
}

  obtenerParque(parqueId: number): void {
    this.parqueService.getParqueDetalleXId(parqueId)
    .subscribe(response => {
      this._parque = response.Entidad;
      console.log(this._parque);
    });
  }

    vergaleria() : void {
      let dialogRef = this.dialog.open(GaleriareservasComponent, {
        height: '700px',
        width: '1024px',
        data: {
          imagenes: this.imagenesGaleria
        }
      });
  
      dialogRef.afterClosed().subscribe(result => {
      });
    }      

    preserva() : void {
      //debugger;
      console.log('Pre reserva');
      if(this.objreservas.length > 0)
      {        

        this._reserva.precioTotalReserva = this.total;
        this._reserva.estadoId = this.estadoReservaPendiente;      
        let momentVariable = moment(new Date(),'DDMMYYYY');
        let stringvalue = momentVariable.format('DD/MM/YYYY');
        this._reserva.fechaGeneracionReserva = stringvalue;
        
        this._reserva.observacionReserva;        
        const jwt = this.authService.getToken();
        var infoToken = (jwt !== null && jwt !== '') ? this.authService.transformarToken(jwt) : '';
        var idUsurio = (infoToken !== null && infoToken !== '') ? infoToken.primarysid : "0";
        this._reserva.usuarioReservaId = idUsurio;
               
      //   if(this.ReservaForm.dirty && this.ReservaForm.valid) {
      
        const datos = Object.assign({}, this._reserva);
        
        const datosDetalle = Object.assign({}, this.objreservas);

        // for (let i = 0; i < this.objreservas.length; i++) {
        //   let element = this.objreservas[i];        
        //   this._DetalleReserva.reservaId = 1;                  
        //   this._DetalleReserva.servicioId = element["ServicioParqueId"];
        //   this._DetalleReserva.fechaInico = element["datafInicio"] == 'NA' ? this._DetalleReserva.fechafin = element["datafReser"] : this._DetalleReserva.fechaInico = element["datafInicio"];
        //   this._DetalleReserva.fechafin = element["datafReser"] == 'NA' ? this._DetalleReserva.fechafin = element["datafF"] : this._DetalleReserva.fechafin = element["datafReser"] ;
        //   this._DetalleReserva.precioTotalServicio = element["PrecioServicio"];
        //   //this._DetalleReserva.precioTotalDescuento = element[""];
        //   this._DetalleReserva.precioTotalDescuento = 0.1;
        //   this._DetalleReserva.adquirioServicio = false;
        //   this._DetalleReserva.cantidad = 1;          
        //   // this.reservasService.crearPreReservasDetalle(datosDetalle)        
        //   // .subscribe(response => {
        //   //   console.log(response.Entidad.Entidad);
        //   //   if(response.Codigo == 200 && response.Entidad.Entidad !== 0)
        //   //   {
        //   //     this.appBase.openSnackBar("Se guardo el detalle de la pre-reserva con éxito.", "exito-notificacion");
        //   //     this.objreservas = [];
        //   //   }
        //   //   else
        //   //   {
        //   //     this.appBase.openSnackBar("Registro fallido del detalle de la pre-reserva, intente nuevamente o comuniquese con el administrador del sistema.","error-notificacion");
        //   //   }
        //   // });
        // }
        console.log("Detalle");
        console.log(datosDetalle);

        console.log("Datos");
        console.log(datos);
        
        this.reservasService.crearPreReservas(datos, datosDetalle)
        .subscribe(response => {
        console.log(response.Entidad.Entidad);
        if(response.Codigo == 200 && response.Entidad.Entidad !== 0)
        {
          this.appBase.openSnackBar("Se guardo la pre-reserva con éxito.", "exito-notificacion");
          this.objreservas = [];
        }
        else
        {
          this.appBase.openSnackBar("Registro fallido, intente nuevamente o comuniquese con el administrador del sistema.","error-notificacion");
        }
      });

     

      
      
    }
     
  }
 }
