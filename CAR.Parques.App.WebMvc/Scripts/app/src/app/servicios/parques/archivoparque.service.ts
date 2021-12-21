import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { archivoParque } from 'src/app/models/parques/archivoParque';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ArchivoparqueService {
  constructor(private httpClient: HttpClient) {}

  public postFileImagen(archivoParque: archivoParque): any {
    const formData = new FormData();
    formData.append('ArchivoParqueId', '0');
    formData.append('TipoArchivoId', archivoParque.tipoArchivoId.toString());
    formData.append(
      'TituloArchivParque',
      archivoParque.tituloArchivParque.toString()
    );
    formData.append(
      'ObservacionArchivoParque',
      archivoParque.observacionArchivoParque.toString()
    );
    formData.append(
      'RutaArchivoParque',
      archivoParque.rutaArchivoParque.toString()
    );
    formData.append('Orden', archivoParque.orden.toString());
    formData.append('ParqueId', archivoParque.parqueId.toString());
    formData.append(
      'ByteArchivo',
      archivoParque.imagenParque,
      archivoParque.nombreImagen
    );
    return this.httpClient.post(
      `${environment.urlService}ArchivoParqueUiApi/Crear`,
      formData
    );
  }

  public consultarArchivosParque(tipoArchivoId: number, parqueId: number) {
    return this.httpClient.get<any>(
      `${environment.urlService}ArchivoParqueUiApi/ConsultarArchivoParque/${tipoArchivoId}/${parqueId}`
    );
  }

  obtenerArchivosParque(parqueId: number): Observable<any> {
    return this.httpClient.get<any>(
      `${environment.urlService}ArchivoParqueUiApi/ConsultarArchivosParque/${parqueId}`
    );
  }

  eliminarArchivoParque(archivoParqueId: number): Observable<any> {
    return this.httpClient.delete<any>(
      `${environment.urlService}ArchivoParqueUiApi/EliminarArchivo/${archivoParqueId}`
    );
  }

  obtenerTiposArchivo(): Observable<any> {
    return this.httpClient.get<any>(
      `${environment.urlService}ArchivoParqueUiApi/ConsultarTiposArchivo`
    );
  }
}
