import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TipoServicioService {

  constructor(private httpClient: HttpClient) { }

  getTipoServicios() : Observable<any> {
    return this.httpClient.get<any>(`${environment.urlService}TipoServicioUiApi/ConsultarListadoTipoServicio`);
  }
}
