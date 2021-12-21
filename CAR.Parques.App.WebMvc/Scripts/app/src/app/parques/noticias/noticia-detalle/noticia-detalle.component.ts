import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as moment from 'moment';
import { noticiaDetalle } from 'src/app/models/GestorContenido/noticiaDetalle';
import { NoticiasService } from 'src/app/servicios/noticias/noticias.service';
import { toHTML } from 'ngx-editor';

@Component({
  selector: 'app-noticia-detalle',
  templateUrl: './noticia-detalle.component.html',
  styleUrls: ['./noticia-detalle.component.scss'],
})
export class NoticiaDetalleComponent implements OnInit {
  idNoticia: number = 0;
  noticia: noticiaDetalle;
  cargado = true;

  constructor(
    private noticiaService: NoticiasService,
    private activateRoute: ActivatedRoute
  ) {
    this.getParams();
  }

  ngOnInit(): void {
    this.noticia = { ...this.noticia };
    this.obtenerNoticiaPorId();
  }

  getParams(): void {
    this.activateRoute.queryParams.subscribe((params) => {
      let id = params['id'];
      if (!isNaN(parseInt(id))) {
        this.idNoticia = id;
      }
    });
  }

  obtenerNoticiaPorId(): void {
    this.noticiaService.obtenerNoticia(this.idNoticia).subscribe(
      (res) => {
        this.cargarNoticia({ noticiaRta: res.Entidad });
      },
      (error) => {
        console.log(error);
      }
    );
  }

  cargarNoticia({ noticiaRta }): void {
    this.noticia.urlImage =
      'data:image/jpeg;base64,' + noticiaRta.ImagenContenido;

    let jsonDoc = JSON.parse(noticiaRta.CuerpoContenido);
    this.noticia.CuerpoContenido = toHTML(jsonDoc);
    this.noticia.fechaCreacion = noticiaRta.FechaCreacion;
    this.noticia.NombreContenido = noticiaRta.NombreContenido;
    this.cargado = true;
  }

  formatearFecha(fecha): string {
    let momentVariable = moment(fecha, 'DD-MM-YYYY');
    let stringvalue = momentVariable.format('YYYY-MM-DD');
    return stringvalue;
  }
}
