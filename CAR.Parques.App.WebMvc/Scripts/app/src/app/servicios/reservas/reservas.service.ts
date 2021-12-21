import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { ServicioList } from 'src/app/models/parques/servicioList';
import { map } from 'rxjs/operators';
import { servicioParque } from 'src/app/models/parques/servicioParque';
import { Reservas } from 'src/app/models/Reserva/reservas';
import { DetalleReserva } from 'src/app/models/Reserva/detalleReserva';
import { reservaDetalleNT } from 'src/app/models/Reserva/reservaDetalleNT';
import { archivoReserva } from 'src/app/models/reservas/archivoReserva';

@Injectable({
  providedIn: 'root',
})
export class ReservaService {
  constructor(private httpClient: HttpClient) {}

  public consultarReservas(
    estadoId: number,
    parqueId: number,
    fechaInicio: string,
    fechaFin: string
  ) {
    //return this.httpClient.get<any>(`${environment.urlService}ReservaUiApi/ConsultarReservasDetalle/${estadoId}`);
    return this.httpClient.get<any>(
      `${environment.urlService}ReservaUiApi/ConsultarReservasDetalle/${estadoId}/${parqueId}/${fechaInicio}/${fechaFin}`
    );
    //return this.httpClient.get<any>(`/Api/EstadoReservaUiApi/ConsultarReservasDetalle/${estadoId}/${parqueId}/${fechaInicio}/${fechaFin}`);
  }

  establecerEstadoReserva(objReserva:any): Observable<any> {
    return this.httpClient.put(`${environment.urlService}ReservaUiApi/EstadoReserva/`, objReserva)
      .pipe(map((response: any) => response));
  }

  public consultarReservasUsuario(usuarioId: number, estadoId: number) {
    let uriReservasUsuario = `${environment.urlService}ReservaUiApi/ReservasUsuario?usuarioId=${usuarioId}&estadoId=${estadoId}`;
    return this.httpClient.get<any>(uriReservasUsuario);
  }

  public crearPreReservas(
    data: Reservas,
    dataDetalle: DetalleReserva[]
  ): Observable<any> {
    debugger;
    var reservaDetalle: reservaDetalleNT = new reservaDetalleNT();
    reservaDetalle.Reserva = data;
    reservaDetalle.Detalle = dataDetalle;
    return this.httpClient
      .post(`${environment.urlService}ReservaUiApi/Crear/`, reservaDetalle)
      .pipe(map((response: any) => response));
  }

  public cargarComprobanteReserva(archivoReserva: archivoReserva) {
    const formData = new FormData();
    formData.append(
      'ArchivoReservaId',
      archivoReserva.archivoReservaId.toString()
    );
    formData.append('ReservaId', archivoReserva.reservaId.toString());
    formData.append(
      'TituloArchivoReserva',
      archivoReserva.tituloArchivoReserva
    );
    formData.append(
      'ByteArchivo',
      archivoReserva.byteArchivo,
      archivoReserva.tituloArchivoReserva
    );
    return this.httpClient.post(
      `${environment.urlService}ReservaUiApi/ArchivoReserva`,
      formData
    );
  }

  public ValidarPreReserva(dataDetalle: DetalleReserva): Observable<any>
  {
    //debugger;
    return this.httpClient.post(`${environment.urlService}ReservaUiApi/ValidarPreReserva/`,dataDetalle)
    .pipe(map((response: any) => response));
  }
}
