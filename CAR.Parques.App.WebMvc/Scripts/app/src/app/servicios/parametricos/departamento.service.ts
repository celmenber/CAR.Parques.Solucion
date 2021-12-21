import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DepartamentoService {

  constructor(private httpClient: HttpClient) { }

  getListadoDepartamentos() : Observable<any> {
    return this.httpClient.get<any>(`${environment.urlService}DepartamentoUiApi/ConsultarListadoDepartamentos`);
  }
}
