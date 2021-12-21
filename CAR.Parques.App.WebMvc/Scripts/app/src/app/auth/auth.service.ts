import { Injectable } from '@angular/core';
import { Role } from './role.enum';
import { Observable, BehaviorSubject, throwError as observableThrowError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import * as decode from 'jwt-decode';
import { catchError, map } from 'rxjs/operators';
import { transformError } from '../common/common';
import { CacheService } from './cache.service';
import { MenuItem } from '../shared/nav-bar/model/menuObject';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends CacheService {

  private readonly authProvider: (email: string, password: string) => Observable<IServerAuthResponse>;
  //Observable par averificar los cambios que ocurren sobre el modelo IAuthStatus
  authStatus = new BehaviorSubject<IAuthStatus>(this.getItem('authStatus') || defaultAuthStatus);

  constructor(private httpClient: HttpClient) { 
    //Es como el base del construtor padre.
    super();
    this.authStatus.subscribe(authStatus => {
      //this.setItem('authStatus', authStatus);
    });
    this.authProvider = this.userAuthProvider;
  }

  private userAuthProvider(email: string, password: string) : Observable<IServerAuthResponse> {
    //debugger;
    return this.httpClient.post<IServerAuthResponse>(`${environment.urlService}Token/Autenticar`, { Email: email, PasswordUsuario: password });
  }

  login(email: string, password: string): Observable<IAuthStatus> {  
    this.logout();
    const loginResponse = this.authProvider(email, password).pipe(
      map(value => {
        console.log(value);      
        const result = decode(value.access_Token);
        this.setToken(value.access_Token);
        return result as IAuthStatus;
      }),
      catchError(transformError)
    );

    loginResponse.subscribe(
      res => {
        //El metodo next le actualiza los nuevos valores del desencriptado del access_token
        this.authStatus.next(res);
      },
      err => {
        this.logout();
        return observableThrowError(err);
      }
    );

    return loginResponse;
  }

  logout(){
    this.clearToken();
    this.authStatus.next(defaultAuthStatus);
  }

  private setToken(jwt: string){
    this.setItem('jwt', jwt);
  }

  getToken() : string {
    return this.getItem('jwt') || '';
  }

  private clearToken() {
    this.removeItem('jwt');
  }

  getAuthStatus(): IAuthStatus{
    return this.getItem('authStatus');
  }

  transformarToken(jwt: string) : any {
    if(!(jwt == null || jwt === ''))
    {
      const result = decode(jwt);
      //console.log(result);
      return result as IAuthStatus;
    }
    return defaultAuthStatus;
  }
}
//Modelo
export interface IAuthStatus {
  role: number;
  role_name: string;
  primarysid: number;
  unique_name: string;
  email: string;
  certserialnumber: string;
  nameid: string;
  menu: string;
}

interface IServerAuthResponse {
  access_Token: string;
}

const defaultAuthStatus: IAuthStatus = { role: 0, role_name: null, primarysid: null, unique_name: null,  email: null, certserialnumber: null, nameid: null, menu: null};