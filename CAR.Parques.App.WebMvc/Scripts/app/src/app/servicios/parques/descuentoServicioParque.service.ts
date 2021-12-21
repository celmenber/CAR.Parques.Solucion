import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { descuentoServicioParque } from 'src/app/models/parques/descuentoServicioParque';

@Injectable({
  providedIn: 'root'
})
export class DescuentoServicioparqueService {

  constructor(private httpClient: HttpClient) { }

  public consultarDescuentoTipousuario(descuentoId: number)
  {
    return this.httpClient.get<any>(`${environment.urlService}DescuentoTipoUsuarioUiApi/ConsultarDetalleXId/${descuentoId}`);
  }

  public eliminarDescuentoTipousuario(descuentoId: number)
  {
    return this.httpClient.delete<any>(`${environment.urlService}DescuentoTipoUsuarioUiApi/Eliminar/${descuentoId}`);
  }

  actualizarDescuentoTipousuario(data: descuentoServicioParque) : Observable<any>
  {
    return this.httpClient.put(`${environment.urlService}DescuentoTipoUsuarioUiApi/Actualizar`, data)
    .pipe(map((response : any) => response));
  }

  guardarDescuentoTipousuario(data: descuentoServicioParque) : Observable<any> {
    return this.httpClient.post(`${environment.urlService}DescuentoTipoUsuarioUiApi/Crear`,data)
    .pipe(map((response: any) => response));
  }
}
