import { Component, OnInit, ViewChild, TemplateRef, ChangeDetectorRef, AfterViewInit } from '@angular/core';
import { ServicioparqueService } from 'src/app/servicios/parques/servicioparque.service';
import { GrillaComponent } from 'src/app/shared/grilla/grilla.component';
import { ServicioList } from 'src/app/models/parques/servicioList';
import { EditarServicioParqueComponent } from '../editar-servicio-parque/editar-servicio-parque.component';
import { MatDialog } from '@angular/material/dialog';
import { DetalleServicioParqueComponent } from '../detalle-servicio-parque/detalle-servicio-parque.component';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';
import { ActivatedRoute } from '@angular/router';
import { NuevoServicioParqueComponent } from '../nuevo-servicio-parque/nuevo-servicio-parque.component';
import { NuevoDescuentoServicioComponent } from '../nuevo-descuento-servicio/nuevo-descuento-servicio.component';
import { DescuentoServicioparqueService } from 'src/app/servicios/parques/descuentoServicioParque.service';
import { EditarDescuentoServicioComponent } from '../editar-descuento-servicio/editar-descuento-servicio.component';

@Component({
  selector: 'app-servicios-list',
  templateUrl: './servicios-list.component.html',
  styleUrls: ['./servicios-list.component.scss']
})
export class ServiciosListComponent implements OnInit, AfterViewInit {

  items: Object[] = [];
  public columns: object[] = [];
  public detailColumns:  Object[] = [];
  @ViewChild("tableView") tableView: GrillaComponent<any>;
  @ViewChild("servicioIdTemplate") private servicioIdTemplate: TemplateRef<any>;
  @ViewChild("AccionesTemplate") private accionesTemplate: TemplateRef<any>;
  @ViewChild("DescripcionTemplate") private descripcionTemplate: TemplateRef<any>;
  @ViewChild("CreadoPorTemplate") private creadoPorTemplate: TemplateRef<any>;
  @ViewChild("FechaCreacionTemplate") private fechaCreacionTemplate: TemplateRef<any>;
  @ViewChild("ImpuestoTemplate") private impuestoTemplate: TemplateRef<any>;
  @ViewChild("TipoTemplate") private tipoTemplate: TemplateRef<any>;
  @ViewChild("AccionesDescuentoTemplate") private accionesDescuentoTemplate: TemplateRef<any>;
  
  public mobile: boolean;
  numberOfRecords: number = 0;
  parqueId: number = 0;

  constructor(private ref: ChangeDetectorRef, 
    private serviciosparqueService: ServicioparqueService,
    private descuentoService: DescuentoServicioparqueService,
    public dialog: MatDialog,
    private appBase: NotificacionComponent,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.parqueId = parseInt(this.route.snapshot.params['id']);
    this.obtenerServiciosParque(this.parqueId);
    if (window.screen.width <= 768) {
      this.mobile = true;
    }
    else {
      this.mobile = false;
    }
  }

  ngAfterViewInit() : void {
    this.columns = this.getColumns();
    this.detailColumns = this.getDetailsColumns();
    this.ref.detectChanges();
  }

  obtenerServiciosParque(parqueId: number): void {
    this.serviciosparqueService.consultarServiciosParque(parqueId)
    .subscribe(response => {
      this.items = response.Entidad.Entidad;
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
        name:"-",
        flexGrow: 0.3,
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
        name: "Estado",
        prop : "EstadoServicio",
        flexGrow: 0.3,
        sortable: true
      },
    ];

    let listadoColumnasEscritorio: Object[] = [
      {
        name: "Descripción",
        //prop: "DescripcionServicioParque",
        flexGrow: 1,
        cellTemplate: this.descripcionTemplate
      },
      /*{
        name: "Creado por",
        flexGrow: 0.5,
        //prop : "UsuarioCreacionNombre",
        cellTemplate: this.creadoPorTemplate
      },
      {
        name: "Fecha Creación",
        //prop : "FechaCreacion",
        cellTemplate: this.fechaCreacionTemplate,
        flexGrow: 0.5,
      },*/
      {
        name: "Imp.",
        //prop : "ImpuestoServicio",
        cellTemplate: this.impuestoTemplate,
        flexGrow: 0.3,
      },
      {
        name: "Tipo",
        //prop : "TipoServicio",
        cellTemplate: this.tipoTemplate,
        flexGrow: 0.3,
      }
    ];

    let listadoConsolidado : Object[] = [];
    if(this.mobile === false) {
      //listadoConsolidado = Object.assign(listadoColumnasMobile,listadoColumnasEscritorio);
      listadoConsolidado = listadoColumnasMobile.concat(listadoColumnasEscritorio);
    }
    else {
      listadoConsolidado = listadoColumnasMobile;
    }
    return listadoConsolidado;
  }

  private getDetailsColumns(): Object[] {
    return [
      {
        name:"-",
        flexGrow: 0.3,
        cellTemplate: this.accionesDescuentoTemplate,
      },
      {
        name: "Tipo Usuario",
        flexGrow: 0.5,
        prop : "TipoUsuario"
      },
      {
        name: "Descuento",
        prop: "Descuento",
        flexGrow: 1
      }
    ];
  }

  toggleExpandRow(row:any) : void {
    this.tableView.toggleExpandRow(row);
    this.ref.detectChanges();
  }

  changePage(event: any): void{
    this.obtenerServiciosParque(this.parqueId);
  }

  editarServicio(servicioId: number) : void {
    let dialogRef = this.dialog.open(EditarServicioParqueComponent, {
      panelClass: "editar-parque-modal-dialog",
      data: {servicioId: servicioId}
    });

    dialogRef.afterClosed().subscribe(result => {
      this.obtenerServiciosParque(this.parqueId);
    });
  }

  eliminarServicioParque(servicioId: number) : void {
    this.serviciosparqueService.eliminarServicioParque(servicioId)
    .subscribe(response => {
      this.appBase.openSnackBar("Eliminación correcta.","exito-notificacion");
      this.obtenerServiciosParque(this.parqueId);
    });
  }

  verServicioParque(servicioId: number) : void {
    let dialogRef = this.dialog.open(DetalleServicioParqueComponent, {
      panelClass: "detalle-parque-modal-dialog",
      data: {servicioId: servicioId}
    });
  }

  nuevoDescuentoServicioParque(servicioId: number) : void {
    let dialogRef = this.dialog.open(NuevoDescuentoServicioComponent, {
      panelClass: "editar-parque-modal-dialog",
      data: {servicioId: servicioId}
    });

    dialogRef.afterClosed().subscribe(result => {
      this.obtenerServiciosParque(this.parqueId);
    });
  }

  openDialog() : void {
    let dialogRef = this.dialog.open(NuevoServicioParqueComponent, {
      panelClass: "nuevo-parque-modal-dialog",
      data: {parqueId: this.parqueId}
    });

    dialogRef.afterClosed().subscribe(result => {
      this.obtenerServiciosParque(this.parqueId);
    });
  }

  eliminarDescuentoServicioParque(descuentoId: number) : void {
    this.descuentoService.eliminarDescuentoTipousuario(descuentoId)
    .subscribe(response => {
      this.appBase.openSnackBar("Eliminación correcta.","exito-notificacion");
      this.obtenerServiciosParque(this.parqueId);
    });
  }

  editarDescuentoServicio(descuentoId: number) : void {
    let dialogRef = this.dialog.open(EditarDescuentoServicioComponent, {
      panelClass: "editar-parque-modal-dialog",
      data: {descuentoId: descuentoId}
    });

    dialogRef.afterClosed().subscribe(result => {
      this.obtenerServiciosParque(this.parqueId);
    });
  }
}
