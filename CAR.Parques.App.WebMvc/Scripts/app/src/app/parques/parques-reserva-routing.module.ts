import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'src/app/auth/auth.guard';
import { ParquesListComponent } from './parques-list/parques-list.component';
import { ReservasComponent } from './reservas/reservas.component';
import { NoticiaDetalleComponent } from './noticias/noticia-detalle/noticia-detalle.component';

const parquesReservaRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        component: ParquesListComponent,
      },
      {
        path: 'noticia',
        component: NoticiaDetalleComponent,
      },
      {
        path: 'detallereserva/:id',
        component: ReservasComponent,
      }
    ],
    //canActivate: [AuthGuard],
  },
];

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild(parquesReservaRoutes)],
  exports: [RouterModule],
})
export class PaqueReservaRoutingModule {}
