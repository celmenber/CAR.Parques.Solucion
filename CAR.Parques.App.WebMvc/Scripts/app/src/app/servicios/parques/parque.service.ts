import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { parque } from 'src/app/models/parques/parque';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ParqueService {

  constructor(private httpClient: HttpClient) { }

  getListadoParques() : Observable<any> {
    return this.httpClient.get<any>(`${environment.urlService}ParqueUiApi/ObtenerListadoParquesDetalle`);
  }

  getListadoParquesImage() : Observable<any> {
    return this.httpClient.get<any>(`${environment.urlService}ParqueUiApi/ObtenerListadoParquesDetalle`);
  }

  getParqueDetalleXId(parqueId: number) : Observable<any> {
    return this.httpClient.get<any>(`${environment.urlService}ParqueUiApi/ConsultarDetalleXId/${parqueId}`);
  }

  guardarParque(data: parque) : Observable<any> {
    return this.httpClient.post(`${environment.urlService}ParqueUiApi/Crear`,data)
    .pipe(map((response: any) => response));
  }

  editarParque(data: parque): Observable<any> {
    return this.httpClient.put(`${environment.urlService}ParqueUiApi/Actualizar`, data)
    .pipe(map((response: any) => response));
  }

  eliminarParque(parqueId: number) : Observable<any> {
    return this.httpClient.delete<any>(`${environment.urlService}ParqueUiApi/Eliminar/${parqueId}`);
  }

  getDetalleParqueReservaID(parqueId: number) : Observable<any>{
    return this.httpClient.get<any>(`${environment.urlService}ParqueUiApi/getDetalleParqueReservaID/${parqueId}`);
  }

  getListadoParquesInformacion() : Observable<any> {
    return this.httpClient.get<any>(`${environment.urlService}ParqueUiApi/ObtenerListadoInformacionParques`);
  }
}
