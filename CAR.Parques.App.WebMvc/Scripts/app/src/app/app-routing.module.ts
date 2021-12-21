import { NgModule } from '@angular/core';
import { Routes, RouterModule, ExtraOptions } from '@angular/router';
import { HomeComponent } from './home/home/home.component';
import { NotFoundComponent } from './shared/not-found/not-found.component';
import { LogoutComponent } from './logout/logout.component';
import { AuthGuard } from './auth/auth.guard';
import { HistorialReservasComponent } from './reservas/historial-reservas/historial-reservas.component';
import { ReservasPendientesComponent } from './reservas/reservas-pendientes/reservas-pendientes.component';

const routerOptions: ExtraOptions = {
  onSameUrlNavigation: 'reload',
  scrollPositionRestoration: 'enabled',
  anchorScrolling: 'enabled',
  scrollOffset: [0,64],
  useHash: false
};

const routes: Routes = [
  {
    path: 'login',
    loadChildren: () =>
      import('./login/login.module').then((mod) => mod.LoginModule),
  },
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'parques',
    loadChildren: () =>
      import('./parques/parques-reserva.module').then(
        (mod) => mod.ParqueReservasModule
      ),
    // canActivate: [AuthGuard],
  },
  {
    path: 'historialreservas',
    component: HistorialReservasComponent,
   canActivate: [AuthGuard],
  },
  {
    path: 'reservaspendiente',
    component: ReservasPendientesComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'adminParques',
    loadChildren: () =>
      import('./administracion/parque/parque.module').then(
        (mod) => mod.ParqueModule
      ),
    canActivate: [AuthGuard],
  },
  {
    path: 'adminNoticias',
    loadChildren: () =>
      import('./administracion/noticia/noticia.module').then(
        (mod) => mod.NoticiaModule
      ),
    canActivate: [AuthGuard],
  },
  {
    path: 'adminReservas',
    loadChildren: () =>
      import('./administracion/reservas/reservas.module').then(
        (mod) => mod.ReservasAdmModule
      ),
    canActivate: [AuthGuard],
  },
  {
    path: 'adminUsuarios',
    loadChildren: () =>
      import('./administracion/usuarios/usuario.module').then(
        (mod) => mod.UsuarioModule
      ),
    canActivate: [AuthGuard],
  },
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full',
  },
  {
    path: 'logout',
    component: LogoutComponent,
  },
  {
    path: '**',
    component: NotFoundComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, routerOptions)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
