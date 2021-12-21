import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EstadoReservaService {

  constructor(private httpClient: HttpClient) { }

  getEstados() : Observable<any> {
    return this.httpClient.get<any>(`${environment.urlService}EstadoReservaUiApi/ConsultarListadoEstadoReserva`);
  }
}
