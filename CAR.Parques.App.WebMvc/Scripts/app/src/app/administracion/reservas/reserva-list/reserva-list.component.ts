import { AfterViewInit, ChangeDetectorRef, Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatDialog } from '@angular/material/dialog';
import { MY_DATE_FORMATS } from 'src/app/common/my-date-formats';
import { estadoReserva } from 'src/app/models/parametricos/estadoReserva';
import { parque } from 'src/app/models/parques/parque';
import { reservaDetalle } from 'src/app/models/reservas/reservasDetalle';
import { EstadoReservaService } from 'src/app/servicios/parametricos/estado-reserva.service';
import { ParqueService } from 'src/app/servicios/parques/parque.service';
import { ReservaService } from 'src/app/servicios/reservas/reservas.service';
import { GrillaComponent } from 'src/app/shared/grilla/grilla.component';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';
import { ComprobanteReservaComponent } from '../comprobante-reserva/comprobante-reserva.component';

/** @title Datepicker with different locale */

@Component({
  selector: 'app-reserva-list',
  templateUrl: './reserva-list.component.html',
  styleUrls: ['./reserva-list.component.scss'],
  providers: [ParqueService, ReservaService,
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS }]
})
export class ReservaListComponent implements OnInit, AfterViewInit {

  items: Object[] = [];
  listadoreservaDetalle: reservaDetalle[] = [];
  public columns: object[] = [];
  public detailColumns: Object[] = [];
  _estadoReserva: estadoReserva[] = [];
  parques: parque[] = [];
  adminReservaForm: FormGroup;
  @ViewChild("tableView") tableView: GrillaComponent<any>;
  @ViewChild("reservaIdTemplate") private reservaIdTemplate: TemplateRef<any>;
  @ViewChild("AccionesTemplate") private accionesTemplate: TemplateRef<any>;

  constructor(private ref: ChangeDetectorRef,
    private fb: FormBuilder,
    private estadoReservaService: EstadoReservaService,
    private parquesService: ParqueService,
    private reservaService: ReservaService,
    private appBase: NotificacionComponent,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.construirAdmReservaFormulario();
    this.obtenerEstados();
    this.obtenerParques();
  }

  ngAfterViewInit(): void {
    this.columns = this.getColumns();
    this.detailColumns = this.getDetailsColumns();
    this.ref.detectChanges();
  }

  obtenerEstados(): void {
    this.estadoReservaService.getEstados()
      .subscribe(response => {
        console.log(response.Entidad.Entidad);
        this._estadoReserva = response.Entidad.Entidad;
        const estadoReservaTodos: estadoReserva = {
          EstadoReservaId: 0,
          NombreEstadoReserva: 'Todos',
          DescripcionEstado: '-'
        };
        this._estadoReserva.push(estadoReservaTodos);
      });
  }

  obtenerParques(): void {
    this.parquesService.getListadoParquesImage()
      .subscribe(response => {
        console.log(response.Entidad);
        this.parques = response.Entidad;
        const parqueTodos: parque = {
          ParqueId: 0,
          NombreParque: 'Todos',
          Activo: true,
          DepartamentoId: null,
          Direccion: null,
          InicialesParque: null,
          MunicipioId: null,
          NombreDepartamento: null,
          NombreMunicipio: null,
          Observacion: null,
          Telefono: null,
          imagen: null,
          urlImagen: null,
          Color: null,
          colorFondo: null,
          LinkUbicacionGoogle: null,
        };
        this.parques.push(parqueTodos);
      });
  }

  construirAdmReservaFormulario(): void {
    this.adminReservaForm = this.fb.group({
      EstadoReservaId: new FormControl({ value: '' }),
      ParqueId: new FormControl({ value: '' }),
      FechaInicio: new FormControl(),
      FechaFin: new FormControl()
    });
  }

  buscarReservas(): void {
    console.log(this.adminReservaForm.value);
    var filtro = this.adminReservaForm.value;
    //console.log(filtro.FechaInicio.format("DDMMYYYY"));
    //console.log(filtro.FechaFin.format("DDMMYYYY"));
    filtro.FechaInicio = (filtro.FechaInicio !== null && filtro.FechaInicio !== 'NA') ? filtro.FechaInicio.format("DDMMYYYY") : 'NA';
    filtro.FechaFin = (filtro.FechaInicio !== null && filtro.FechaInicio !== 'NA') ? filtro.FechaFin.format("DDMMYYYY") : 'NA';
    this.reservaService.consultarReservas
      (filtro.EstadoReservaId, filtro.ParqueId, filtro.FechaInicio, filtro.FechaFin)
      .subscribe(response => {
        //console.log(response.Entidad.Entidad.length);
        for (let i = 0; i < response.Entidad.Entidad.length; i++) {
          console.log(response.Entidad.Entidad[i].ListadoDetalleReserva.length);
          for (let j = 0; j < response.Entidad.Entidad[i].ListadoDetalleReserva.length; j++) {
            console.log(response.Entidad.Entidad[i].ListadoDetalleReserva[j].FechaInicio);
            console.log(response.Entidad.Entidad[i].ListadoDetalleReserva[j].FechaFin);
            response.Entidad.Entidad[i].ListadoDetalleReserva[j].FechaInicio = (new Date(response.Entidad.Entidad[i].ListadoDetalleReserva[j].FechaInicio)).toLocaleDateString();
            response.Entidad.Entidad[i].ListadoDetalleReserva[j].FechaFin = (new Date(response.Entidad.Entidad[i].ListadoDetalleReserva[j].FechaFin)).toLocaleDateString();
          }
        }
        this.listadoreservaDetalle = response.Entidad.Entidad;        
        console.log(this.listadoreservaDetalle);
      });
  }

  private getColumns(): object[] {
    let listadoColumnas: Object[] = [
      {
        name: "",
        flexGrow: 0.1,
        cellTemplate: this.reservaIdTemplate
      },
      {
        name: "-",
        flexGrow: 0.1,
        cellTemplate: this.accionesTemplate,
      },
      {
        name: "cod. Reserva",
        prop: "ReservaId",
        flexGrow: 0.2,
        sortable: true
      },
      {
        name: "Estado",
        prop: "NombreEstado",
        flexGrow: 0.5,
        sortable: true
      },
      {
        name: "Usuario",
        prop: "UsuarioReserva",
        flexGrow: 0.3,
        sortable: true,
      },
      {
        name: "Fecha Generacion",
        prop: "FechaGeneracionReserva",
        flexGrow: 0.3,
        sortable: true
      },
      {
        name: "Precio",
        prop: "PrecioTotalReserva",
        flexGrow: 0.3,
        sortable: true
      },
    ];

    return listadoColumnas;
  }

  toggleExpandRow(row: any): void {
    this.tableView.toggleExpandRow(row);
    this.ref.detectChanges();
  }

  private getDetailsColumns(): Object[] {
    return [
      {
        name: "Servicio",
        flexGrow: 1,
        prop: "NombreServicio"
      },
      {
        name: "Nombre Parque",
        prop: "NombreParque",
        flexGrow: 1
      },
      {
        name: "Total Servicio",
        prop: "PrecioTotalServicio",
        flexGrow: 0.5
      },
      {
        name: "Total con Descuento",
        flexGrow: 0.5,
        prop: "PrecioTotalDescuento"
      },
      {
        name: "Fecha Inicio",
        prop: "FechaInicio",
        flexGrow: 1
      },
      {
        name: "Fecha Fin",
        flexGrow: 0.5,
        prop: "FechaFin"
      },
      {
        name: "Cantidad",
        prop: "Cantidad",
        flexGrow: 1
      }
    ];
  }

  verComprobanteServicio(reservaId: number): void {    
    let dialogRef = this.dialog.open(ComprobanteReservaComponent, {
      panelClass: "editar-parque-modal-dialog",
      data: { reservaId: reservaId }
    });
    dialogRef.afterClosed().subscribe(result => {
      this.buscarReservas();
    });
  }
}
