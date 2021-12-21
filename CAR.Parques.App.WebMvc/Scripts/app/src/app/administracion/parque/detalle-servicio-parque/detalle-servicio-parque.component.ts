import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { servicioParque } from 'src/app/models/parques/servicioParque';
import { ParqueService } from 'src/app/servicios/parques/parque.service';
import { ServicioparqueService } from 'src/app/servicios/parques/servicioparque.service';

export interface DialogData {
  servicioId:number;
}

@Component({
  selector: 'app-detalle-servicio-parque',
  templateUrl: './detalle-servicio-parque.component.html',
  styleUrls: ['./detalle-servicio-parque.component.scss']
})
export class DetalleServicioParqueComponent implements OnInit {

  _servicioParque: servicioParque = new servicioParque();

  constructor(private servicioParqueService: ServicioparqueService,
    private dialogRef: MatDialogRef<DetalleServicioParqueComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: DialogData) { 
      this.servicioParqueDetalle(data.servicioId);
  }

  ngOnInit(): void {
  }

  servicioParqueDetalle(id: number) : void {
    this.servicioParqueService.consultarServicioParqueDetalleXId(id)
    .subscribe(response => {
      console.log(response.Entidad.Entidad);
      this._servicioParque = response.Entidad.Entidad;
    });
  }
}
