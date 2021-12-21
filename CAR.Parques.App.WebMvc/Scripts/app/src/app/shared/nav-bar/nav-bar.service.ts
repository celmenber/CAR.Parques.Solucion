import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NavBarService {

  constructor(private httpClient: HttpClient) { }
  
  getMenu(idPerfil: number): Observable<any> {
    //debugger;
    return this.httpClient.get<any>(`${environment.urlService}MenuUiApi/ObtenerMenuPerfil/${idPerfil}`);
  }
}
