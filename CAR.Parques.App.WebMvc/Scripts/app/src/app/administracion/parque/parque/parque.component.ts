import { Component, OnInit } from '@angular/core';
import { ParqueService } from 'src/app/servicios/parques/parque.service';
import { parque } from 'src/app/models/parques/parque';
import { MatDialog } from  '@angular/material/dialog';
import { NuevoParqueComponent } from '../nuevo-parque/nuevo-parque.component';
import { EditarParqueComponent } from '../editar-parque/editar-parque.component';
import { DetalleParqueComponent } from '../detalle-parque/detalle-parque.component';
import { ArchivoparqueService } from 'src/app/servicios/parques/archivoparque.service';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';

@Component({
  selector: 'app-parque',
  templateUrl: './parque.component.html',
  styleUrls: ['./parque.component.scss'],
  providers: [ParqueService]
})
export class ParqueComponent implements OnInit {

  parques: parque[] = [];

  constructor(private parqueService: ParqueService, 
    private archivoParqueService: ArchivoparqueService, 
    public dialog: MatDialog,
    private appBase: NotificacionComponent) { }

  ngOnInit(): void {
    this.getListadoParques();
  }

  getListadoParques(): void {
    this.parqueService.getListadoParques()
    .subscribe(
      response => {
        this.parques = response.Entidad;
        let contador=0;
        for (let parque of this.parques) { 
          this.archivoParqueService.consultarArchivosParque(1,parque.ParqueId)
          .subscribe(
            response2 => {
                var objetoArchivo = response2.Entidad.Entidad[0];
                if(objetoArchivo!== undefined)
                {
                  var bytes = objetoArchivo.ByteArchivo;
                  var url = 'data:image/jpeg;base64,' + bytes;
                  parque.urlImagen = url;
                }
                contador++;
            }
          );
        }
        contador=0;
      }
    );
  }

  openDialog() : void {
    let dialogRef = this.dialog.open(NuevoParqueComponent, {
      panelClass: "nuevo-parque-modal-dialog"
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getListadoParques();
    });
  }

  editarparque(parqueId: number) : void {
    let dialogRef = this.dialog.open(EditarParqueComponent, {
      panelClass: "editar-parque-modal-dialog",
      data: {parqueId: parqueId}
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getListadoParques();
    });
  }

  eliminarParque(parqueId: number) : void {
    console.log(parqueId);
    this.parqueService.eliminarParque(parqueId)
    .subscribe(response => {
      this.appBase.openSnackBar("Eliminación correcta.","exito-notificacion");
      this.getListadoParques();
    });
  }

  archivosParque(parqueId: number) : void {
    this.parqueService.eliminarParque(parqueId)
    .subscribe(response => {
      this.appBase.openSnackBar("Eliminación correcta.","exito-notificacion");
      this.getListadoParques();
    });
  }

  verParque(parqueId: number) : void {
    let dialogRef = this.dialog.open(DetalleParqueComponent, {
      panelClass: "detalle-parque-modal-dialog",
      data: {parqueId: parqueId}
    });
  }

}
