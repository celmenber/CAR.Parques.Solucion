import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { ServicioList } from 'src/app/models/parques/servicioList';
import { map } from 'rxjs/operators';
import { servicioParque } from 'src/app/models/parques/servicioParque';

@Injectable({
  providedIn: 'root'
})
export class ServicioparqueService {

  constructor(private httpClient: HttpClient) { }

  public consultarServiciosParque(parqueId: number)
  {
    return this.httpClient.get<any>(`${environment.urlService}ServicioParqueUiApi/ConsultarServiciosParque/${parqueId}`);
  }

  public eliminarServicioParque(servicioParqueId: number)
  {
    return this.httpClient.delete<any>(`${environment.urlService}ServicioParqueUiApi/Eliminar/${servicioParqueId}`);
  }

  consultarServicioParqueDetalleXId(servicioParqueId: number) : Observable<any> {
    return this.httpClient.get<any>(`${environment.urlService}ServicioParqueUiApi/ConsultarDetalleXId/${servicioParqueId}`);
  }

  actualizarServicioParque(data: servicioParque) : Observable<any>
  {
    return this.httpClient.put(`${environment.urlService}ServicioParqueUiApi/Actualizar`, data)
    .pipe(map((response : any) => response));
  }

  guardarServicioParque(data: servicioParque) : Observable<any> {
    return this.httpClient.post(`${environment.urlService}ServicioParqueUiApi/Crear`,data)
    .pipe(map((response: any) => response));
  }
}
