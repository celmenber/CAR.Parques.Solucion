import { Component, OnInit, Inject } from '@angular/core';
import { ParqueService } from 'src/app/servicios/parques/parque.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { parque } from 'src/app/models/parques/parque';
import { ArchivoparqueService } from 'src/app/servicios/parques/archivoparque.service';

export interface DialogData {
  parqueId:number;
}

@Component({
  selector: 'app-detalle-parque',
  templateUrl: './detalle-parque.component.html',
  styleUrls: ['./detalle-parque.component.scss'],
  providers: [ParqueService]
})
export class DetalleParqueComponent implements OnInit {

  _parque: parque = new parque();

  constructor(private parqueService: ParqueService, 
    private archivoParqueService: ArchivoparqueService,
    public dialogRef: MatDialogRef<DetalleParqueComponent>, @Inject(MAT_DIALOG_DATA) public data: DialogData) { 
    this.parqueDetalle(data.parqueId);
  }

  ngOnInit(): void {
  }

  parqueDetalle(id: number) : void {
    this.parqueService.getParqueDetalleXId(id)
    .subscribe(response => {
      this._parque = response.Entidad;
      this.archivoParqueService.consultarArchivosParque(1,this._parque.ParqueId)
      .subscribe(
        response2 =>{
          var objetoArchivo = response2.Entidad.Entidad[0];
          if(objetoArchivo!== undefined)
          {
            var bytes = objetoArchivo.ByteArchivo;
            var url = 'data:image/jpeg;base64,' + bytes;
            this._parque.urlImagen = url;
          }
        }
      );
    });
  }
}
