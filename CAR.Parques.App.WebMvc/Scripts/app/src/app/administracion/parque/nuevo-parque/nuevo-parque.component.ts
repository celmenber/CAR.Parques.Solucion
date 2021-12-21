import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormsModule } from '@angular/forms';
import { parque } from 'src/app/models/parques/parque';
import { ParqueService } from 'src/app/servicios/parques/parque.service';
import { MatDialogRef } from '@angular/material/dialog';
import { DepartamentoService } from 'src/app/servicios/parametricos/departamento.service';
import { MunicipioService } from 'src/app/servicios/parametricos/municipio.service';
import { departamento } from 'src/app/models/parametricos/departamento';
import { municipio } from 'src/app/models/parametricos/municipio';
import { espaciosBlancoValidator } from 'src/app/shared/validators/espaciosBlancoValidator';
import { SoloLetrasValidator } from 'src/app/shared/validators/SoloLetrasValidator';
import { SoloNumerosValidator } from 'src/app/shared/validators/SoloNumerosValidaror';
import { ArchivoparqueService } from 'src/app/servicios/parques/archivoparque.service';
import { archivoParque } from 'src/app/models/parques/archivoParque';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';

@Component({
  selector: 'app-nuevo-parque',
  templateUrl: './nuevo-parque.component.html',
  styleUrls: ['./nuevo-parque.component.scss'],
  providers: [ParqueService, DepartamentoService, MunicipioService]
})

export class NuevoParqueComponent implements OnInit {

  nuevoParqueForm: FormGroup;
  _departamentos: departamento[] = [];
  _municipios: municipio[] = [];
  selected: number;
  parque: parque;
  checked = false;
  //Objetos para Carga de Imagen
  public respuestaImagenEnviada;
  public resultadoCarga;
  public nombreArchivo = "Seleccione Imagen Principal ...";
  public archivoCargado : boolean = false;
  public imagenParque: File;
  //public archivoParqueObject : archivoParque;

  constructor(private fb: FormBuilder, private parqueService: ParqueService, 
    private departamentoService: DepartamentoService, private municipioService: MunicipioService,
    public dialogRef: MatDialogRef<NuevoParqueComponent>,
    private archivoParqueService: ArchivoparqueService,
    private appBase: NotificacionComponent) { }

  ngOnInit(): void {
    this.construirNuevoParqueFormulario();
    this.obtenerDepartamentos();
  }

  construirNuevoParqueFormulario() : void {
    this.nuevoParqueForm = this.fb.group({
      NombreParque: ['', Validators.compose([Validators.required])],
      InicialesParque: ['', Validators.compose([Validators.required, Validators.maxLength(2),SoloLetrasValidator.soloLetras])],
      Activo: [''],
      Direccion: ['', Validators.compose([Validators.required])],
      departamentoId: ['', [Validators.required]],
      MunicipioId:['',[Validators.required]],
      Telefono: ['', Validators.compose([Validators.required, SoloNumerosValidator.soloNumeros])],
      Observacion: ['']
    });
  }

  obtenerMunicipiosXDepartamento(id: number, event: any) : void {
    if(event.isUserInput==true) {
      this.municipioService.getListadoMunicipiosXDepartamento(id)
      .subscribe(response => {
      this._municipios = response.Entidad.Entidad;
    });
    }
  }

  cargarArchivo(event: any) : void {
    this.imagenParque = event.target.files[0];
    console.log(this.imagenParque);
    this.nombreArchivo = this.imagenParque.name;
    this.archivoCargado = true;
  }

  obtenerDepartamentos() : void {
    this.departamentoService.getListadoDepartamentos()
    .subscribe(response => {
      this._departamentos = response.Entidad.Entidad;
    });
  }

  guardar() : void {
    if(this.nuevoParqueForm.dirty && this.nuevoParqueForm.valid) {
      const datos = Object.assign({}, this.parque, this.nuevoParqueForm.value);
      this.parqueService.guardarParque(datos)
      .subscribe(response => {
        console.log(response.Entidad.Entidad);
        if(response.Codigo == 200 && response.Entidad.Entidad !== 0)
        {
          this.construirObjetoImagen(response.Entidad.Entidad, datos.NombreParque);
        }
        else
        {
          this.appBase.openSnackBar("Registro fallido, intente nuevamente o comuniquese con el administrador del sistema.","error-notificacion");
        }
        this.dialogRef.close();
      });
    }
    else if (!this.nuevoParqueForm.dirty) {
      this.nuevoParqueForm.reset();
    }
    else {
      this.appBase.openSnackBar("Inserción correcta.","info-notificacion");
    }
  }

  public construirObjetoImagen(parqueId: number, titulo: string)
  {
    const archivoParqueObject = new archivoParque();
    archivoParqueObject.imagenParque = this.imagenParque;
    archivoParqueObject.nombreImagen = this.imagenParque.name;
    archivoParqueObject.tipoArchivoId = 1;
    archivoParqueObject.tituloArchivParque = (`${titulo} Imagen Principal`);
    archivoParqueObject.observacionArchivoParque = (`Imagen Principal del parque ${titulo}`);
    archivoParqueObject.rutaArchivoParque = "";
    archivoParqueObject.orden = 1;
    archivoParqueObject.parqueId = parqueId;
    this.archivoParqueService.postFileImagen(archivoParqueObject)
    .subscribe(response => {
      console.log(response.Entidad.Entidad);
      if(response.Codigo == 200 && response.Entidad.Entidad !== 0)
      {
        this.appBase.openSnackBar("Se guardo el parque con exito.", "exito-notificacion");
      }
      else
      {
        this.appBase.openSnackBar("Se presento un error, por favor comuniquese con el administrador del sistema.", "error-notificacion");
      }
    });
  }

  /*public cargandoImagen(files: FileList){

		this.archivoParqueService.postFileImagen(files[0]).subscribe(
			response => {
				this.respuestaImagenEnviada = response; 
				if(this.respuestaImagenEnviada <= 1){
					console.log("Error en el servidor"); 
				}else{

					if(this.respuestaImagenEnviada.code == 200 && this.respuestaImagenEnviada.status == "success"){

						this.resultadoCarga = 1;

					}else{
						this.resultadoCarga = 2;
					}

				}
			},
			error => {
				console.log(<any>error);
			});
	}*/
}
