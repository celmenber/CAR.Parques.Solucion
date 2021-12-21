import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MunicipioService {

  constructor(private httpClient: HttpClient) { }

  getListadoMunicipiosXDepartamento(departamentoId: number) : Observable<any> {
    return this.httpClient.get<any>(`${environment.urlService}MunicipioUiApi/ConsultarListadoMunicipiosXDepartamento/${departamentoId}`);
  }
}
