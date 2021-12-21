import { Component, OnInit } from '@angular/core';
import { ParqueService } from 'src/app/servicios/parques/parque.service';
import { parque } from 'src/app/models/parques/parque';
import { MatDialog } from '@angular/material/dialog';
import { ArchivoparqueService } from 'src/app/servicios/parques/archivoparque.service';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';
import { DetalleParqueComponent } from '../../administracion/parque/detalle-parque/detalle-parque.component';
import { InformacionParqueComponent } from '../informacion-parque/informacion-parque.component';
import { parqueInformacion } from 'src/app/models/parques/parqueInformacion';

@Component({
  selector: 'app-parques-list',
  templateUrl: './parques-list.component.html',
  styleUrls: ['./parques-list.component.scss'],
  providers: [ParqueService]
})
export class ParquesListComponent implements OnInit {

  parques: parqueInformacion[] = [];
  slides : any[] = [];

  constructor(private parqueService: ParqueService, 
    private archivoParqueService: ArchivoparqueService, 
    public dialog: MatDialog,
    private appBase: NotificacionComponent) { }

  ngOnInit(): void {
    this.getListadoParques();
  }

  getListadoParques(): void {
    this.parqueService.getListadoParquesInformacion()
    .subscribe(
      response => {
        //console.log(response);
        this.parques = response.Entidad;
        console.log(this.parques);
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
                  this.slides.push({'urlImagen': url, 'color': parque.Color, 'nombre': parque.NombreParque, 'observacion': parque.Observacion });
                }
                contador++;
            }
          );
        }
        contador=0;
      }
    );
    
    //*for (let item of this.parques) {
    //}

    console.log(this.slides);
  }

  verParque(parqueId: number) : void {
    let dialogRef = this.dialog.open(DetalleParqueComponent, {
      panelClass: "detalle-parque-modal-dialog",
      data: {parqueId: parqueId}
    });
  }

  verInformacion(parqueEntidad: parque) : void {
    let dialogRef = this.dialog.open(InformacionParqueComponent, {
      panelClass: "informacion-parque-modal-dialog",
      data: { parque: parqueEntidad }
    });
  }

  hexToRgb(h: string, isPct: boolean) {
    let r: string = '0', g: string = '0', b: string = '0';
    isPct = isPct === true;
    
    if (h.length == 4) {
      r = "0x" + h[1] + h[1];
      g = "0x" + h[2] + h[2];
      b = "0x" + h[3] + h[3];
      } 
      else if (h.length == 7) {
        r = "0x" + h[1] + h[2];
        g = "0x" + h[3] + h[4];
        b = "0x" + h[5] + h[6];
      }
  
      if (isPct) {
          r = (parseInt(r) / 255 * 100).toFixed(1).toString();
          g = (parseInt(g) / 255 * 100).toFixed(1).toString();
          b = (parseInt(b) / 255 * 100).toFixed(1).toString();
      }
      //console.log("rgb(" + (isPct ? r + "%," + g + "%," + b + "%" : +r + "," + +g + "," + +b) + ", 0.5)");
      return "background-color: rgb(" + (isPct ? r + "%," + g + "%," + b + "%" : +r + "," + +g + "," + +b) + ", 0.5)";
  }
}
