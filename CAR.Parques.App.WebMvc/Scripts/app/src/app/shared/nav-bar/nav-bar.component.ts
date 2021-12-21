import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';
import { NavBarService } from './nav-bar.service';
import { MenuItem } from './model/menuObject';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
  providers: [NavBarService]
})
export class NavBarComponent implements OnInit {

  _displayLogin = true;
  _authStatus = null;
  _menu: any[] = undefined;

  constructor (private authService: AuthService, private navBarService: NavBarService){
    //this.getEntidadMenu(0);
  }


  getEntidadMenu(idPerfil: number) : void {
    this.navBarService.getMenu(idPerfil)
    .subscribe(response => {      
      if(response.Codigo === 1)
      {
        this._menu = response.Entidad.Entidad
        .sort((a, b) => a.TipoModuloId - b.TipoModuloId)
        .sort((a, b) => a.OrdenMenu - b.OrdenMenu);        
      }
      else
      {
        this._menu = undefined;
      }
    });
  }

  ngOnInit() : void {
    this.authService.authStatus.subscribe(
      authStatus => {
        const jwt = this.authService.getToken();
        setTimeout(() => (this._displayLogin = (jwt == null || jwt === ''), 0));
        this._authStatus = this.authService.transformarToken(jwt);
        if(!(jwt == null || jwt === ''))
        {
          //this._authStatus = this.authService.getAuthStatus();
          if(this._authStatus.menu !== null)
          {
            console.log('entro a flujo 1');
            this._menu = JSON.parse(this._authStatus.menu)
            .sort((a, b) => a.TipoModuloId - b.TipoModuloId)
            .sort((a, b) => a.OrdenMenu - b.OrdenMenu);
          }
        }
        else
        {          
          console.log('entro a flujo 2');
          this.getEntidadMenu(0);
        }        
      }
    )
  } 

  get displayLogin() {
    return this._displayLogin;
  }
}