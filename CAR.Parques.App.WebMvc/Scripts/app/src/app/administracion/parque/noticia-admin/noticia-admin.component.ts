import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
} from '@angular/forms';

import { Validators, Editor, Toolbar, toDoc } from 'ngx-editor';

import { IGestorContenidoModel } from '../../../models/GestorContenido/IGestorContenidoModel';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';

import { NoticiasService } from 'src/app/servicios/noticias/noticias.service';

@Component({
  selector: 'app-noticia-admin',
  templateUrl: './noticia-admin.component.html',
  styleUrls: ['./noticia-admin.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class NoticiaAdminComponent implements OnInit, OnDestroy {
  //Objetos para Carga de Imagen
  public respuestaImagenEnviada;
  public resultadoCarga;
  public nombreArchivo = 'Seleccione archivo ...';
  public archivoCargado: boolean = false;
  public imagenNoticia: File;

  constructor(
    private fb: FormBuilder,
    private noticiaService: NoticiasService,
    private appBase: NotificacionComponent
  ) {}
  formNoticia: FormGroup;
  editordoc = '<h1></h1>';

  editorConfig = {
    placeHolder: 'Digite aqui su texto',
  };

  editor: Editor;
  // toolbar: Toolbar = [
  //   ['bold', 'italic'],
  //   ['underline', 'strike'],
  //   ['code', 'blockquote'],
  //   ['ordered_list', 'bullet_list'],
  //   [{ heading: ['h1', 'h2', 'h3', 'h4', 'h5', 'h6'] }],
  //   ['link', 'image'],
  //   ['text_color', 'background_color'],
  //   ['align_left', 'align_center', 'align_right', 'align_justify'],
  // ];

  construirFormularioNoticia(): void {
    this.formNoticia = this.fb.group({
      editorContent: new FormControl(this.editordoc, Validators.required()),
      titulo: new FormControl('', Validators.required()),
      fechaInicioVigencia: new FormControl('', Validators.required()),
      fechaFinVigencia: new FormControl('', Validators.required()),
    });
  }

  get doc(): AbstractControl {
    return this.formNoticia.get('editorContent');
  }

  ngOnInit(): void {
    this.editor = new Editor();
    this.construirFormularioNoticia();
  }

  cargarArchivo(event: any): void {
    this.imagenNoticia = event.target.files[0];
    console.log(this.imagenNoticia);
    this.nombreArchivo = this.imagenNoticia.name;
    this.archivoCargado = true;
  }

  guardar(): void {
    if (this.formNoticia.dirty && this.formNoticia.valid) {
      this.construirObjetoImagen();
    } else if (!this.formNoticia.dirty) {
      this.formNoticia.reset();
    } else {
      this.appBase.openSnackBar('Eliminación correcta.', 'info-notificacion');
    }
  }

  public construirObjetoImagen() {
    let tituloArchivo = this.formNoticia.value.TituloArchivParque;

    const noticiaObject: IGestorContenidoModel = {
      Activo: true,
      ContenidoId: 0,
      FechaInicioVigencia: '4/10/2021', //this.formNoticia.value.fechaInicioVigencia,
      CuerpoContenido: JSON.stringify(
        toDoc(this.formNoticia.value.editorContent)
      ),
      FechaFinVigencia: '4/13/2021', //this.formNoticia.value.fechaFinVigencia,
      ImagenContenido: this.imagenNoticia,
      NombreContenido: this.formNoticia.value.titulo,
      TipoContenidoId: 1,
      TituloContenido: this.nombreArchivo,
      URLRedireccion: '',
    };

    console.log(noticiaObject);

    // archivoParqueObject.imagenParque = this.imagenNoticia;
    // archivoParqueObject.nombreImagen = this.imagenNoticia.name;
    // archivoParqueObject.tipoArchivoId = this.formNoticia.value.TipoArchivoId;
    // archivoParqueObject.tituloArchivParque = tituloArchivo;
    // archivoParqueObject.observacionArchivoParque = this.formNoticia.value.Observacion;
    // archivoParqueObject.rutaArchivoParque = '';
    // archivoParqueObject.orden = 1;

    this.noticiaService.guardarNoticia(noticiaObject).subscribe((response) => {
      console.log(response.Entidad.Entidad);
      if (response.Codigo == 200 && response.Entidad.Entidad !== 0) {
        this.appBase.openSnackBar(
          'Se guardo el archivo con exito.',
          'exito-notificacion'
        );
      } else {
        this.appBase.openSnackBar(
          'Se presento un error, por favor comuniquese con el administrador del sistema.',
          'error-notificacion'
        );
      }
    });
  }

  ngOnDestroy(): void {
    this.editor.destroy();
  }
}
