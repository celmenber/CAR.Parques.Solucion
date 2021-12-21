import { AfterViewInit, ChangeDetectorRef, Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { UsuarioService } from 'src/app/servicios/usuario/usuario.service';
import { GrillaComponent } from 'src/app/shared/grilla/grilla.component';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';
import { EditarUsuarioComponent } from '../editar-usuario/editar-usuario.component';
import { NuevoUsuarioComponent } from '../nuevo-usuario/nuevo-usuario.component';

@Component({
  selector: 'app-adm-usuarios-list',
  templateUrl: './adm-usuarios-list.component.html',
  styleUrls: ['./adm-usuarios-list.component.scss']
})
export class AdmUsuariosListComponent implements OnInit, AfterViewInit {

  mobile: boolean = false;
  items: Object[] = [];
  public columns: object[] = [];
  public detailColumns:  Object[] = [];
  temp = [];
  @ViewChild("tableView") tableView: GrillaComponent<any>;
  @ViewChild("AccionesTemplate") private accionesTemplate: TemplateRef<any>;

  constructor(private ref: ChangeDetectorRef,
    public dialog: MatDialog,
    public usuarioService: UsuarioService,
    private appBase: NotificacionComponent,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.obtenerUsuarios();
    if (window.screen.width <= 768) {
      this.mobile = true;
    }
    else {
      this.mobile = false;
    }
  }

  ngAfterViewInit() : void {
    this.columns = this.getColumns();
    console.log(this.columns);
    //this.detailColumns = this.getDetailsColumns();
    this.ref.detectChanges();
  }

  private getColumns(): object[] {
    let listadoColumnasMobile : Object[] = [
      /*{
        name: "",
        flexGrow: this.mobile !== true ? 0.06 : 0.1,
        cellTemplate: this.servicioIdTemplate
      },*/
      {
        name:"-",
        flexGrow: 0.3,
        cellTemplate: this.accionesTemplate,
      },
      {
        name: "ID",
        prop: "UsuarioId",
        flexGrow: 0.3,
        sortable: true
      },
      {
        name: "Documento",
        prop : "Documento",
        flexGrow: 0.5,
        sortable: true,
      },
      {
        name: "Nombre",
        prop : "Nombre1",
        flexGrow: 0.5,
        sortable: true
      },
      {
        name: "Apellido",
        prop : "Apellido1",
        flexGrow: 0.5,
        sortable: true
      },
      {
        name: "Correo",
        prop : "Email",
        flexGrow: 0.5,
        sortable: true
      },
      {
        name: "Tipo Usuario",
        prop : "TipoUsuario",
        flexGrow: 0.5,
        sortable: false
      }
    ];

    /*let listadoColumnasEscritorio: Object[] = [
      {
        name: "Descripción",
        //prop: "DescripcionServicioParque",
        flexGrow: 1,
        cellTemplate: this.descripcionTemplate
      },*/
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
      /*{
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
    ];*/

    let listadoConsolidado : Object[] = [];
    if(this.mobile === false) {
      listadoConsolidado = listadoColumnasMobile;
    }
    else {
      listadoConsolidado = listadoColumnasMobile;
    }
    return listadoConsolidado;
  }

  eliminarUsuario(usuarioId: number) : void {
    this.usuarioService.eliminarUsuario(usuarioId)
    .subscribe(response => {
      this.appBase.openSnackBar("Eliminación correcta.","exito-notificacion");
      this.obtenerUsuarios();
    });
  }

  editarUsuario(usuarioId: number) : void {
    let dialogRef = this.dialog.open(EditarUsuarioComponent, {
      panelClass: "editar-parque-modal-dialog",
      data: {usuarioId: usuarioId}
    });

    dialogRef.afterClosed().subscribe(result => {
      this.obtenerUsuarios();
    });
  }

  openDialog(){
    let dialogRef = this.dialog.open(NuevoUsuarioComponent, {
      panelClass: "modal-dialog-grande"
    });

    dialogRef.afterClosed().subscribe(result => {
      this.obtenerUsuarios();
    });
  }

  obtenerUsuarios(): void {
    this.usuarioService.getListadoUsuariosDetalles()
    .subscribe(response => {
      console.log(response);
      this.temp = response.Entidad;
      this.items = response.Entidad;
    });
  }

  updateFilter(event) {
    const val = event.target.value.toLowerCase();
    //console.log(this.temp);
    // filter our data
    const temp = this.temp.filter(function (d) {
      console.log(d);
      return d.Nombre1.toLowerCase().indexOf(val) !== -1 || 
      !val || 
      d.Apellido1.toLowerCase().indexOf(val) !== -1 ||
      d.Documento.toLowerCase().indexOf(val) !== -1;
    });
    //console.log(temp);
    // update the rows
    this.items = temp;
    // Whenever the filter changes, always go back to the first page
//    this.tableView.offset = 0;
  }

  fetch(cb) {
    const req = new XMLHttpRequest();
    req.open('GET', `assets/data/company.json`);

    req.onload = () => {
      cb(JSON.parse(req.response));
    };

    req.send();
  }
}
