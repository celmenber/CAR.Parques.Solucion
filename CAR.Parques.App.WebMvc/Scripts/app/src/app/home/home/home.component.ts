import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as moment from 'moment';
import { NoticiasService } from 'src/app/servicios/noticias/noticias.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  noticias = [];
  mostrar: boolean = false;
  parques = [
  {'urlImagen': 'https://parques.car.gov.co/imagenes/88441cabanas_represa.jpg', 'color': null, 'nombre': null, 'observacion': null}, 
  {'urlImagen': 'https://parques.car.gov.co/imagenes/2989389844microsThumb1.jpg', 'color': null, 'nombre': "Dato 2", 'observacion': "Observaciones 2"},
  {'urlImagen': 'https://parques.car.gov.co/imagenes/53298caba%C3%B1acasaloma.jpg', 'color': null, 'nombre': "Dato 3", 'observacion': "Observaciones 3"}, 
  {'urlImagen': 'https://parques.car.gov.co/imagenes/Alquiler%20de%20botes%20para%20navegaci%C3%B3n%20a%20remo.JPG', 'color': null, 'nombre': "Dato 4", 'observacion': "Observaciones 4"}, 
  {'urlImagen': 'https://parques.car.gov.co/imagenes/Pradera%20para%20picnic.png', 'color': null, 'nombre': "Dato 5", 'observacion': "Observaciones 5"}];

  constructor(
    private router: Router,
    private noticiaService: NoticiasService
  ) {}

  ngOnInit(): void {
    this.obtenerListadoNoticias();
  }

  obtenerListadoNoticias(): void {
    this.noticiaService.obtenerListadoNoticiasVigentes().subscribe(
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
    this.router.navigate(['/parques/noticia'], {
      queryParams: { id: newsId },
    });
  }

  formatearFecha(fecha): string {
    let momentVariable = moment(fecha, 'YYYY-MM-DD');
    let stringvalue = momentVariable.format('YYYY-MM-DD');
    return stringvalue;
  }
}
