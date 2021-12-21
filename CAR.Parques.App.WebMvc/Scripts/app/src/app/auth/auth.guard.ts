import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanActivateChild, CanLoad, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService, IAuthStatus } from './auth.service';
import { MenuItem } from '../shared/nav-bar/model/menuObject';
import { NotificacionComponent } from '../shared/notificacion/notificacion.component';
import { element } from 'protractor';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanActivateChild, CanLoad {

  protected currentAuthStatus: IAuthStatus;
  protected menuActual: MenuItem[] = [];

  constructor(private authService: AuthService, protected router: Router, private appBase: NotificacionComponent) {
    this.authService.authStatus.subscribe(
      //authStatus => (this.currentAuthStatus = (this.authService.getAuthStatus()))      
      authStatus => (this.currentAuthStatus = (this.authService.transformarToken(this.authService.getToken())))
    );
  }

  canLoad(route: import("@angular/router").Route, segments: import("@angular/router").UrlSegment[]): boolean | Observable<boolean> | Promise<boolean> {
    return this.checkLogin();
  }
  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    return this.checkPermissions(childRoute);
  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.checkPermissions(next);
  }

  protected checkLogin() {
    if ((this.authService.getToken() == null || this.authService.getToken() === '')) {
      this.appBase.openSnackBar("Debes iniciar sesión para continuar.", "error-notificacion");
      this.router.navigate(['login']);
      return false;
    }
    return true;
  }

  protected checkPermissions(route?: ActivatedRouteSnapshot) {
    let roleMatch = false;
    if (route) {
      const ruta = route.routeConfig.children === undefined ? `/${route.url[0].path}` : `/${route.parent.url}`;
      this.menuActual = JSON.parse(this.currentAuthStatus.menu);      
      //if(route.routeConfig.children === undefined)
      //{
      //const ruta = `/${route.url[0].path}`; 
      //}
      //else
      //{
      //route.routeConfig.children.forEach(element => console.log(element));
      //const ruta = `/${route.parent.url}`; 
      //console.log("Ruta Raiz " + rutaRaiz);
      //const ruta = `/${route.routeConfig.children[1].path}`; 
      //}

      if (this.menuActual) 
      {             
        console.log(this.menuActual);
        var dato = this.menuActual.find(x => (x.RutaMenu == ruta || x.RutaMenu.replace('/Parques','') ==  ruta));
        //const expectedRole = route.data.expectedRole;
        //debugger;
        if (dato) {
          //roleMatch = this.currentAuthStatus.role === expectedRole;
          roleMatch = true;
        }
      }
    }

    if (!roleMatch) {
      this.appBase.openSnackBar("No tiene los permisos para ver este recurso.", "error-notificacion");
      this.router.navigate(['home']);
      return false;
    }

    return true;
  }
}
