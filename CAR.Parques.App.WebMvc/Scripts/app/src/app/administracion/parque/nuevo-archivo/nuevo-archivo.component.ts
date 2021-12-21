import { Component, Inject, OnInit } from '@angular/core';
import { ArchivoparqueService } from 'src/app/servicios/parques/archivoparque.service';
import { FormGroup, FormBuilder, Validators, FormsModule } from '@angular/forms';
import { tipoArchivo } from 'src/app/models/parametricos/tipoArchivo';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { archivoParque } from 'src/app/models/parques/archivoParque';

@Component({
  selector: 'app-nuevo-archivo',
  templateUrl: './nuevo-archivo.component.html',
  styleUrls: ['./nuevo-archivo.component.scss'],
  providers: [ArchivoparqueService]
})
export class NuevoArchivoComponent implements OnInit {

  nuevoArchivoForm: FormGroup;
  _tiposArchivo: tipoArchivo[] = [];
  parqueId: number = 0;
  nombreParque: string;

  //Objetos para Carga de Imagen
  public respuestaImagenEnviada;
  public resultadoCarga;
  public nombreArchivo = "Seleccione archivo ...";
  public archivoCargado: boolean = false;
  public archivoParque: File;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private archivoParqueService: ArchivoparqueService,
    private appBase: NotificacionComponent,
    public dialogRef: MatDialogRef<NuevoArchivoComponent>,
  ) { }

  ngOnInit(): void {    
    this.parqueId = this.data.parqueId;
    this.construirNuevoArchivoFormulario();
    this.obtenerTiposArchivo();
  }

  construirNuevoArchivoFormulario(): void {
    this.nuevoArchivoForm = this.fb.group({
      TituloArchivParque: ['', Validators.compose([Validators.required])],
      Observacion: [''],
      TipoArchivoId: ['', [Validators.required]]
    });
  }

  obtenerTiposArchivo(): void {
    this.archivoParqueService.obtenerTiposArchivo()
      .subscribe(
        response => {
          this._tiposArchivo = response.Entidad.Entidad.filter(function (obj) { return obj.TipoArchivoId != 1 });;
        });
  }

  cargarArchivo(event: any): void {
    this.archivoParque = event.target.files[0];
    console.log(this.archivoParque);
    this.nombreArchivo = this.archivoParque.name;
    this.archivoCargado = true;
  }


  guardar(): void {

    if (this.nuevoArchivoForm.dirty && this.nuevoArchivoForm.valid) {

      this.construirObjetoImagen();

    }
    else if (!this.nuevoArchivoForm.dirty) {
      this.nuevoArchivoForm.reset();
    }
    else {
      this.appBase.openSnackBar("Eliminación correcta.", "info-notificacion");
    }
  }

  public construirObjetoImagen() {
    let tituloArchivo = this.nuevoArchivoForm.value.TituloArchivParque;
    const archivoParqueObject = new archivoParque();
    archivoParqueObject.imagenParque = this.archivoParque;
    archivoParqueObject.nombreImagen = this.archivoParque.name;
    archivoParqueObject.tipoArchivoId = this.nuevoArchivoForm.value.TipoArchivoId;
    archivoParqueObject.tituloArchivParque = tituloArchivo;
    archivoParqueObject.observacionArchivoParque = this.nuevoArchivoForm.value.Observacion;
    archivoParqueObject.rutaArchivoParque = "";
    archivoParqueObject.orden = 1;
    archivoParqueObject.parqueId = this.parqueId;

    this.archivoParqueService.postFileImagen(archivoParqueObject)
      .subscribe(response => {
        console.log(response.Entidad.Entidad);
        if (response.Codigo == 200 && response.Entidad.Entidad !== 0) {
          this.appBase.openSnackBar("Se guardo el archivo con exito.", "exito-notificacion");
        }
        else {
          this.appBase.openSnackBar("Se presento un error, por favor comuniquese con el administrador del sistema.", "error-notificacion");
        }
      });
  }
}
