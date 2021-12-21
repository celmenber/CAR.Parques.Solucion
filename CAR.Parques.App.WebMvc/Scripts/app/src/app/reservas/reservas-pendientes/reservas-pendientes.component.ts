import {
  ChangeDetectorRef,
  Component,
  OnInit,
  TemplateRef,
  ViewChild,
} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { reservaDetalle } from 'src/app/models/reservas/reservasDetalle';
import { ReservaService } from 'src/app/servicios/reservas/reservas.service';
import { GrillaComponent } from 'src/app/shared/grilla/grilla.component';
import { ComprobanteReservaComponent } from '../comprobante-reserva/comprobante-reserva.component';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-reservas-pendientes',
  templateUrl: './reservas-pendientes.component.html',
  styleUrls: ['./reservas-pendientes.component.scss'],
})
export class ReservasPendientesComponent implements OnInit {
  listadoreservaDetalle: reservaDetalle[] = [];
  public columns: object[] = [];
  public detailColumns: Object[] = [];
  estadoReservaPendiente: number = 2;
  reservaId: number = 0;
  usuarioReserva: string;

  @ViewChild('tableView') tableView: GrillaComponent<any>;
  @ViewChild('reservaIdTemplate') private reservaIdTemplate: TemplateRef<any>;
  @ViewChild('AccionesTemplate') private accionesTemplate: TemplateRef<any>;

  constructor(
    private ref: ChangeDetectorRef,
    private reservaService: ReservaService,
    public dialog: MatDialog,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.buscarReservas();
  }

  ngAfterViewInit(): void {
    this.columns = this.getColumns();
    this.detailColumns = this.getDetailsColumns();
    this.ref.detectChanges();
  }

  buscarReservas(): void {
    //Usuario
    const jwt = this.authService.getToken();
    var infoToken = (jwt !== null && jwt !== '') ? this.authService.transformarToken(jwt) : '';
    var idUsurio = (infoToken !== null && infoToken !== '') ? infoToken.primarysid : "0";

    this.reservaService
      .consultarReservasUsuario(idUsurio, this.estadoReservaPendiente)
      .subscribe((response) => {
        for (let i = 0; i < response.Entidad.Entidad.length; i++) {
          console.log(response.Entidad.Entidad[i].ListadoDetalleReserva.length);
          for (
            let j = 0;
            j < response.Entidad.Entidad[i].ListadoDetalleReserva.length;
            j++
          ) {
            console.log(
              response.Entidad.Entidad[i].ListadoDetalleReserva[j].FechaInicio
            );
            console.log(
              response.Entidad.Entidad[i].ListadoDetalleReserva[j].FechaFin
            );
            response.Entidad.Entidad[i].ListadoDetalleReserva[j].FechaInicio =
              new Date(
                response.Entidad.Entidad[i].ListadoDetalleReserva[j].FechaInicio
              ).toLocaleDateString();
            response.Entidad.Entidad[i].ListadoDetalleReserva[j].FechaFin =
              new Date(
                response.Entidad.Entidad[i].ListadoDetalleReserva[j].FechaFin
              ).toLocaleDateString();
          }
        }
        this.listadoreservaDetalle = response.Entidad.Entidad;
        let dataReserva = this.listadoreservaDetalle[0];
        this.usuarioReserva = dataReserva.UsuarioReserva;
        this.reservaId = dataReserva.ReservaId;

        console.log(this.listadoreservaDetalle);
        console.log(dataReserva);
      });
  }

  private getColumns(): object[] {
    let listadoColumnas: Object[] = [
      {
        name: '',
        flexGrow: 0.1,
        cellTemplate: this.reservaIdTemplate,
      },
      {
        name: 'cod. Reserva',
        prop: 'ReservaId',
        flexGrow: 0.2,
        sortable: true,
      },
      {
        name: 'Estado',
        prop: 'NombreEstado',
        flexGrow: 0.5,
        sortable: true,
      },
      // {
      //   name: 'Usuario',
      //   prop: 'UsuarioReserva',
      //   flexGrow: 0.3,
      //   sortable: true,
      // },
      {
        name: 'Fecha Generacion',
        prop: 'FechaGeneracionReserva',
        flexGrow: 0.3,
        sortable: true,
      },
      {
        name: 'Valor',
        prop: 'PrecioTotalReserva',
        flexGrow: 0.3,
        sortable: true,
      },
      {
        name: '-',
        flexGrow: 0.3,
        cellTemplate: this.accionesTemplate,
      },
    ];

    return listadoColumnas;
  }

  private getDetailsColumns(): Object[] {
    return [
      {
        name: 'Servicio',
        flexGrow: 1,
        prop: 'NombreServicio',
      },
      {
        name: 'Nombre Parque',
        prop: 'NombreParque',
        flexGrow: 1,
      },
      {
        name: 'Total Servicio',
        prop: 'PrecioTotalServicio',
        flexGrow: 0.5,
      },
      {
        name: 'Total con Descuento',
        flexGrow: 0.5,
        prop: 'PrecioTotalDescuento',
      },
      {
        name: 'Fecha Inicio',
        prop: 'FechaInicio',
        flexGrow: 1,
      },
      {
        name: 'Fecha Fin',
        flexGrow: 0.5,
        prop: 'FechaFin',
      },
      {
        name: 'Cantidad',
        prop: 'Cantidad',
        flexGrow: 1,
      },
    ];
  }

  toggleExpandRow(row: any): void {
    this.tableView.toggleExpandRow(row);
    this.ref.detectChanges();
  }

  cargarComprobanteServicio(reservaId: Number): void {
    let dialogRef = this.dialog.open(ComprobanteReservaComponent, {
      panelClass: 'comprobante-reserva-modal-dialog',
      data: {
        reservaId: reservaId,
      },
    });
    dialogRef.afterClosed().subscribe((result) => {
      this.buscarReservas();
    });
  }
}
