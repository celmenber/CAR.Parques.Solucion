import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { gestorContenidoModel } from 'src/app/models/GestorContenido/gestorContenidoModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class NoticiasService {
  constructor(private httpClient: HttpClient) {}

  private urlApi: string = 'NoticiasUiApi';

  guardarNoticia(noticia: gestorContenidoModel): any {
    const formData = new FormData();
    formData.append('ContenidoId', noticia.ContenidoId.toString());
    formData.append('TipoContenidoId', noticia.TipoContenidoId.toString());
    formData.append('NombreContenido', noticia.NombreContenido);
    formData.append('TituloContenido', noticia.TituloContenido);
    formData.append('CuerpoContenido', noticia.CuerpoContenido);
    formData.append('URLRedireccion', noticia.URLRedireccion);
    formData.append('FechaInicioVigencia', noticia.FechaInicioVigencia);
    formData.append('FechaFinVigencia', noticia.FechaFinVigencia);

    if (noticia.ImagenContenido) {
      formData.append(
        'ImagenContenido',
        noticia.ImagenContenido,
        noticia.TituloContenido
      );
    }

    return noticia.ContenidoId != 0
      ? this.actualizar(formData)
      : this.crear(formData);
  }

  private crear(noticia: FormData) {
    return this.httpClient.post(
      `${environment.urlService}${this.urlApi}/Crear`,
      noticia
    );
  }

  private actualizar(noticia: FormData) {
    return this.httpClient.post(
      `${environment.urlService}${this.urlApi}/Editar`,
      noticia
    );
  }

  obtenerListadoNoticias() {
    return this.httpClient.get<any>(
      `${environment.urlService}${this.urlApi}/ObtenerListadoNoticias`
    );
  }

  obtenerListadoNoticiasVigentes() {
    return this.httpClient.get<any>(
      `${environment.urlService}${this.urlApi}/NoticiasVigentes`
    );
  }

  obtenerNoticia(noticiaId: number): Observable<any> {
    return this.httpClient.get<any>(
      `${environment.urlService}${this.urlApi}/ObtenerNoticia/${noticiaId}`
    );
  }

  eliminar(noticiaId: number): Observable<any> {
    return this.httpClient.delete<any>(
      `${environment.urlService}${this.urlApi}/Eliminar/${noticiaId}`
    );
  }
}
