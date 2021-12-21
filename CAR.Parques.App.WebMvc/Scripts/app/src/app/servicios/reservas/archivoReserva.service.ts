import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { archivoParque } from 'src/app/models/parques/archivoParque';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ArchivoReservaService {
  constructor(private httpClient: HttpClient) {}

  obtenerArchivosReserva(reservaId: number): Observable<any> {
    return this.httpClient.get<any>(
      `${environment.urlService}ReservaUiApi/ArchivoReserva/${reservaId}`
    );
  }
}
