import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ArchivoparqueService } from 'src/app/servicios/parques/archivoparque.service';
 
export interface DialogData {
  parqueId:number;
  imagenes: any[];
}

@Component({
  selector: 'app-galeriareservas',
  templateUrl: './galeriareservas.component.html',
  styleUrls: ['./galeriareservas.component.scss']
})
export class GaleriareservasComponent implements OnInit {

  parqueId: number = 0;
  imgGaleria: any[] = [];

  constructor( 
    private archivoParqueService: ArchivoparqueService,
    public dialogRef: MatDialogRef<GaleriareservasComponent>, @Inject(MAT_DIALOG_DATA) public data: DialogData) { 
    this.imgGaleria = data.imagenes;
  }

  ngOnInit(): void {
  }

}
