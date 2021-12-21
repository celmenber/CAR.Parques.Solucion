import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { parque } from 'src/app/models/parques/parque';
import { ParqueService } from 'src/app/servicios/parques/parque.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DepartamentoService } from 'src/app/servicios/parametricos/departamento.service';
import { MunicipioService } from 'src/app/servicios/parametricos/municipio.service';
import { departamento } from 'src/app/models/parametricos/departamento';
import { municipio } from 'src/app/models/parametricos/municipio';
import { espaciosBlancoValidator } from 'src/app/shared/validators/espaciosBlancoValidator';
import { SoloLetrasValidator } from 'src/app/shared/validators/SoloLetrasValidator';
import { SoloNumerosValidator } from 'src/app/shared/validators/SoloNumerosValidaror';
import { ArchivoparqueService } from 'src/app/servicios/parques/archivoparque.service';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';

export interface DialogData {
  parqueId:number;
}

@Component({
  selector: 'app-editar-parque',
  templateUrl: './editar-parque.component.html',
  styleUrls: ['./editar-parque.component.scss'],
  providers: [ParqueService, DepartamentoService, MunicipioService]
})
export class EditarParqueComponent implements OnInit {

  _parque: parque = new parque;
  editarParqueForm: FormGroup;
  _departamentos: departamento[] = [];
  _municipios: municipio[] = [];
  public nombreArchivo = "Seleccione Imagen Principal ...";
  public imagenParque: File;
  public archivoCargado : boolean = false;

  constructor(private parqueService: ParqueService, 
    public dialogRef: MatDialogRef<EditarParqueComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private fb: FormBuilder,
    private archivoParqueService: ArchivoparqueService,
    private municipioService: MunicipioService,
    private departamentoService: DepartamentoService,
    private appBase: NotificacionComponent) { 
      this.parqueDetalle(data.parqueId);
  }

  ngOnInit(): void {
    this.construirEditarParqueFormulario();
    this.obtenerDepartamentos();
  }

  cargarArchivo(event: any) : void {
    this.imagenParque = event.target.files[0];
    console.log(this.imagenParque);
    this.nombreArchivo = this.imagenParque.name;
    this.archivoCargado = true;
  }

  construirEditarParqueFormulario() : void {
    this.editarParqueForm = this.fb.group({
      NombreParque: ['', Validators.compose([Validators.required])],
      InicialesParque: ['', Validators.compose([Validators.required, Validators.maxLength(2), espaciosBlancoValidator.noEspacios,SoloLetrasValidator.soloLetras])],
      Activo: [''],
      Direccion: ['', Validators.compose([Validators.required])],
      DepartamentoId: ['', [Validators.required]],
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

  obtenerDepartamentos() : void {
    this.departamentoService.getListadoDepartamentos()
    .subscribe(response => {
      this._departamentos = response.Entidad.Entidad;
    });
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
      this.editarParqueForm.patchValue({
        NombreParque: this._parque .NombreParque,
        InicialesParque: this._parque .InicialesParque,
        Activo: this._parque .Activo,
        Direccion: this._parque .Direccion,
        DepartamentoId: this._parque .DepartamentoId,
        MunicipioId: this._parque .MunicipioId,
        Telefono: this._parque .Telefono,
        Observacion: this._parque .Observacion
      });
    });
  }

  guardar(): void {
    if(this.editarParqueForm.dirty && this.editarParqueForm.valid) {
      const datos = Object.assign({}, this._parque, this.editarParqueForm.value);
      this.parqueService.editarParque(datos)
      .subscribe(response => {
        if(response.Codigo == 200 && response.Entidad.Entidad)
        {
          this.appBase.openSnackBar("Actualización correcta.","exito-notificacion");
        }
        else
        {
          this.appBase.openSnackBar("Registro fallido, intente nuevamente o comuniquese con el administrador del sistema.","error-notificacion");
        }
        this.dialogRef.close();
      });
    }
    else if (!this.editarParqueForm.dirty) {
      this.editarParqueForm.reset();
    }
  }
}
