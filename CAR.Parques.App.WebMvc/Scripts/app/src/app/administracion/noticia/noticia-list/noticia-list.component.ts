import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NoticiasService } from 'src/app/servicios/noticias/noticias.service';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import {
  DateAdapter,
  MAT_DATE_FORMATS,
  MAT_DATE_LOCALE,
} from '@angular/material/core';
import { MY_DATE_FORMATS } from 'src/app/common/my-date-formats';
import * as moment from 'moment';

@Component({
  selector: 'app-noticia-list',
  templateUrl: './noticia-list.component.html',
  styleUrls: ['./noticia-list.component.scss'],
  providers: [
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE],
    },
    { provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS },
  ],
})
export class NoticiaListComponent implements OnInit {
  constructor(
    private router: Router,
    private noticiaService: NoticiasService
  ) {}
  noticias = []; //jsonDoc;

  ngOnInit(): void {
    console.log(this.noticias);
    this.obtenerListadoNoticias();
  }

  redirectToNew(): void {
    this.router.navigate(['/adminNoticias/Noticia']);
  }

  obtenerListadoNoticias(): void {
    this.noticiaService.obtenerListadoNoticias().subscribe(
      (res) => {
        if (res.Entidad) {
          for (let key in res.Entidad) {
            var noticia = res.Entidad[key];
            noticia.urlImage =
              'data:image/jpeg;base64,' + noticia.ImagenContenido;
            this.noticias.push(noticia);
          }
        }
        console.log(this.noticias);
      },
      (error) => {}
    );
  }

  goToDetail(newsId): void {
    this.router.navigate(['/adminNoticias/Noticia'], {
      queryParams: { id: newsId },
    });
  }

  eliminarNoticia(noticiaId): void {
    this.noticiaService.eliminar(noticiaId).subscribe((res) => {
      let index = this.noticias.findIndex((d) => d.ContenidoId === noticiaId);
      this.noticias.splice(index, 1);
    });
  }

  formatearFecha(fecha): string {
    let momentVariable = moment(fecha, 'YYYY-MM-DD');
    let stringvalue = momentVariable.format('YYYY-MM-DD');
    return stringvalue;
  }
}
