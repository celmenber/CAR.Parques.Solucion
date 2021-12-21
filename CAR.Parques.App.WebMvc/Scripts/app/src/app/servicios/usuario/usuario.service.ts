import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { usuario } from 'src/app/models/usuario/usuario';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { restablecerObject, usuarioOlvido } from 'src/app/models/usuario/usuarioOlvido';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private httpClient: HttpClient) { }
  
  guardarUsuario(data: usuario) : Observable<any> {
    return this.httpClient.post(`${environment.urlService}UsuarioUiApi/Crear`, data)
    .pipe(map((response: any) => response));
  }

  olvidoContrasenia(data: usuarioOlvido) : Observable<any> {
    return this.httpClient.post(`${environment.urlService}UsuarioUiApi/OlvidoContrasenia`, data)
    .pipe(map((response: any) => response));
  }

  restablecer(data: restablecerObject) : Observable<any> {
    return this.httpClient.post(`${environment.urlService}UsuarioUiApi/Restablecer`, data)
    .pipe(map((response: any) => response));
  }

  getListadoUsuarios() : Observable<any> {
    return this.httpClient.get<any>(`${environment.urlService}UsuarioUiApi/ConsultarTodosUsuarios`);
  }

  getListadoUsuariosDetalles() : Observable<any> {
    return this.httpClient.get<any>(`${environment.urlService}UsuarioUiApi/ConsultarTodosUsuariosDetalles`);
  }

  getUsuarioId(usuarioId: number) :Observable<any> {
    return this.httpClient.get<any>(`${environment.urlService}UsuarioUiApi/ConsultarUsuario/${usuarioId}`);
  }

  editarUsuario(data: usuario) : Observable<any> {
    return this.httpClient.put(`${environment.urlService}UsuarioUiApi/Actualizar`, data)
    .pipe(map((response: any) => response));
  }

  eliminarUsuario(usuarioId: number) : Observable<any> {
    return this.httpClient.delete<any>(`${environment.urlService}UsuarioUiApi/Eliminar/${usuarioId}`);
  }
}
