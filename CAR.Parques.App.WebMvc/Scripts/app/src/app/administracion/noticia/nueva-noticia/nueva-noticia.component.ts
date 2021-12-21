import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { Editor, Toolbar, toDoc } from 'ngx-editor';
import { MY_DATE_FORMATS } from 'src/app/common/my-date-formats';
import { gestorContenidoModel } from '../../../models/GestorContenido/gestorContenidoModel';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';
import {
  DateAdapter,
  MAT_DATE_FORMATS,
  MAT_DATE_LOCALE,
} from '@angular/material/core';
import { NoticiasService } from 'src/app/servicios/noticias/noticias.service';
import { ActivatedRoute } from '@angular/router';
import * as moment from 'moment';

@Component({
  selector: 'app-nueva-noticia',
  templateUrl: './nueva-noticia.component.html',
  styleUrls: ['./nueva-noticia.component.scss'],
  providers: [
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE],
    },
    { provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS },
  ],
  encapsulation: ViewEncapsulation.None,
})
export class NuevaNoticiaComponent implements OnInit, OnDestroy {
  idNoticia: number = 0;

  //Objetos para Carga de Imagen
  public respuestaImagenEnviada;
  public resultadoCarga;
  public nombreArchivo = 'Seleccione archivo ...';
  public archivoCargado: boolean = false;
  public imagenNoticia: File;

  constructor(
    private fb: FormBuilder,
    private noticiaService: NoticiasService,
    private appBase: NotificacionComponent,
    private activateRoute: ActivatedRoute
  ) {
    this.getParams();
  }

  formNoticia: FormGroup;
  editordoc: string = '';

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

  getParams(): void {
    this.activateRoute.queryParams.subscribe((params) => {
      let id = params['id'];
      if (!isNaN(parseInt(id))) {
        this.idNoticia = id;
      }
    });
  }

  ngOnInit(): void {
    this.editor = new Editor();
    this.construirFormularioNoticia();

    if (this.idNoticia != 0) {
      this.obtenerNoticiaPorId();
    }
  }

  obtenerNoticiaPorId(): void {
    this.noticiaService.obtenerNoticia(this.idNoticia).subscribe(
      (res) => {
        this.editordoc = JSON.parse(res.Entidad.CuerpoContenido);
        this.cargarNoticia(res.Entidad);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  construirFormularioNoticia(): void {
    this.formNoticia = this.fb.group(
      {
        editorContent: new FormControl('', Validators.required),
        titulo: new FormControl('', Validators.required),
        fechaInicioVigencia: new FormControl('', Validators.required),
        fechaFinVigencia: new FormControl('', Validators.required),
      },
      { validator: this.checkDates }
    );
  }

  checkDates(group: FormGroup) {
    let formatoFecha = 'YYYY-MM-DD';
    if (
      moment(group.controls.fechaFinVigencia.value, formatoFecha) <
      moment(group.controls.fechaInicioVigencia.value, formatoFecha)
    ) {
      return { notValid: true, errorRange: true };
    }
    return null;
  }

  cargarNoticia(noticia): void {
    let formatoFecha = 'YYYY-MM-DD';

    let momentFechaInicio = moment(
      noticia.FechaInicioVigencia,
      formatoFecha
    ).toDate();

    let momentFechaFin = moment(
      noticia.FechaFinVigencia,
      formatoFecha
    ).toDate();

    this.formNoticia.patchValue({
      editorContent: this.editordoc,
      fechaInicioVigencia: momentFechaInicio.toISOString(),
      fechaFinVigencia: momentFechaFin.toISOString(),
      titulo: noticia.NombreContenido,
    });
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
    const noticiaObject: gestorContenidoModel = {
      Activo: true,
      ContenidoId: this.idNoticia,
      FechaInicioVigencia: new Date(
        this.formNoticia.value.fechaInicioVigencia
      ).toLocaleDateString(),
      CuerpoContenido: JSON.stringify(
        toDoc(this.formNoticia.value.editorContent)
      ),
      FechaFinVigencia: new Date(
        this.formNoticia.value.fechaFinVigencia
      ).toLocaleDateString(),
      ImagenContenido: this.imagenNoticia,
      NombreContenido: this.formNoticia.value.titulo,
      TipoContenidoId: 1,
      TituloContenido: this.nombreArchivo,
      URLRedireccion: '',
    };

    this.noticiaService.guardarNoticia(noticiaObject).subscribe((response) => {
      console.log(response.Entidad.Entidad);
      if (response.Codigo == 200 && response.Entidad.Entidad !== 0) {
        this.appBase.openSnackBar(
          'La noticia se ha guardado con exito.',
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
