import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TipodocumentoService {

  constructor(private httpClient: HttpClient) { }

  getTipoDocumentos() : Observable<any>  {
    console.log(`${environment.urlService}TipoDocumentoUiApi/ConsultarListadoTipoDocumento`);
    return this.httpClient.get<any>(`${environment.urlService}TipoDocumentoUiApi/ConsultarListadoTipoDocumento`);
  }
}
