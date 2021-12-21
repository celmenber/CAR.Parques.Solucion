import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { parque } from 'src/app/models/parques/parque';
import { MatDialog } from '@angular/material/dialog';
import { ParqueService } from 'src/app/servicios/parques/parque.service';
import { ArchivoparqueService } from 'src/app/servicios/parques/archivoparque.service';
import { archivoParque } from 'src/app/models/parques/archivoParque';
import { NuevoArchivoComponent } from '../nuevo-archivo/nuevo-archivo.component';
import { DomSanitizer } from '@angular/platform-browser';
import { MatCarousel, MatCarouselComponent } from '@ngmodule/material-carousel';

@Component({
  selector: 'app-archivos-list',
  templateUrl: './archivos-list.component.html',
  styleUrls: ['./archivos-list.component.scss']
})
export class ArchivosListComponent implements OnInit {
  public mobile: boolean;
  parqueId: number = 0;
  parque: parque;

  //archivos: any[] = [];
  imagenesGaleria: any[] = [];
  archivosPdf: any[] = [];
  slides: any[] = [];

  constructor(
    private sanitizer: DomSanitizer,
    private parqueService: ParqueService,
    private archivoParqueService: ArchivoparqueService,
    public dialog: MatDialog,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.parqueId = parseInt(this.route.snapshot.params['id']);

    this.cargarInfoParque();

    this.obtenerArchivosParque(this.parqueId);
    if (window.screen.width <= 768) {
      this.mobile = true;
    }
    else {
      this.mobile = false;
    }
  }

  openDialog(): void {
    let dialogRef = this.dialog.open(NuevoArchivoComponent, {
      panelClass: "nuevo-parque-modal-dialog",
      data: {
        parqueId: this.parqueId
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.obtenerArchivosParque(this.parqueId);
    });
  }

  cargarInfoParque() {
    this.parqueService.getParqueDetalleXId(this.parqueId)
      .subscribe(
        response => {
          this.parque = response.Entidad;
        }
      )
  }

  sanitize(url: string) {
    return this.sanitizer.bypassSecurityTrustUrl(url);
  }

  obtenerArchivosParque(parqueId: number): void {
    this.archivoParqueService.obtenerArchivosParque(parqueId)
      .subscribe(
        response => {
          var objetoArchivos = response.Entidad.Entidad;
          if (objetoArchivos !== undefined) {
            //this.archivos = objetoArchivos.filter(function (obj) { return obj.TipoArchivoId != 1 });
            this.archivosPdf = objetoArchivos.filter(function (obj) { return obj.TipoArchivoId == 2 });
            this.imagenesGaleria = objetoArchivos.filter(function (obj) { return obj.TipoArchivoId == 3 });

            for (let archivo of this.imagenesGaleria) {
              var bytes = archivo.ByteArchivo;
              var url = 'data:image/jpeg;base64,' + bytes;
              archivo.rutaArchivoParque = url;
              this.slides.push({ 'image': url, 'ArchivoParqueId': archivo.ArchivoParqueId });
            }

            for (let archivo of this.archivosPdf) {
              var bytes = archivo.ByteArchivo;
              let url = 'data:application/pdf;base64,' + bytes;
              archivo.rutaArchivoParque = url;
            }
          }
        },
        error => {
          var x = error;
        }
      );
  }

  eliminarArchivo(archivoParqueId: number, tipoArchivoId: number): void {
    this.archivoParqueService.eliminarArchivoParque(archivoParqueId)
      .subscribe(
        response => {
          if (response.Entidad) {
            let indexArchivo = -1;
            if (tipoArchivoId == 3) {
              indexArchivo = this.slides.indexOf(this.slides.find(function (archivo) {
                return archivo.ArchivoParqueId == archivoParqueId;
              }));

              if (indexArchivo != -1) {
                this.slides.splice(indexArchivo, 1);
              }
            }
            else{
              indexArchivo = this.archivosPdf.indexOf(this.archivosPdf.find(function (archivo) {
                return archivo.ArchivoParqueId == archivoParqueId;
              }));

              if (indexArchivo != -1) {
                this.archivosPdf.splice(indexArchivo, 1);
              }
            }
          }
        }
      );
  }
}

