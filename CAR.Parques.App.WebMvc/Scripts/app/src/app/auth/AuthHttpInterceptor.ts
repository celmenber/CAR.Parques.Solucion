
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError as observableThrowError } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';
import { AuthService } from './auth.service';
import { CargadorComponent } from '../shared/cargador/cargador.component';
import { CargadorService } from '../servicios/shared/cargador.service';

@Injectable()
export class AuthHttpInterceptor implements HttpInterceptor{
    constructor(private authService: AuthService, private router: Router, private cargadorService: CargadorService) {}
 
    intercept(req: HttpRequest<any>, next: HttpHandler) : Observable<HttpEvent<any>>{
        this.cargadorService.mostrar();
        const jwt = this.authService.getToken();
        var infoToken = (jwt !== null && jwt !== '') ? this.authService.transformarToken(jwt) : '';

        const authRequest = req.clone({ setHeaders: { 
            authorization: `Bearer ${jwt}`,
            UsuarioId: (infoToken !== null && infoToken !== '') ? infoToken.primarysid : "0",
            MenuId: "0",
            "Access-Control-Allow-Origin":'*',
            'Access-Control-Allow-Credentials':'true',
            'Access-Control-Allow-Methods':'GET, POST, OPTIONS, PUT, PATCH, DELETE',
            'Access-Control-Allow-Headers': 'Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers,X-Access-Token,XKey,Authorization'
        }});

        return next.handle(authRequest).pipe(
            finalize(() => this.cargadorService.ocultar()),
            catchError((err, caught) => {
                if(err.status === 401){
                    this.router.navigate(['/login'],{ 
                        queryParams: { redirectUrl: this.router.routerState.snapshot.url }, }); }
                return observableThrowError(err);
            })
        );
    }
}