import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/auth/auth.guard';
import { ReservaListComponent } from './reserva-list/reserva-list.component';

const reservasRoutes : Routes = [
  {
    path:'',
    children: [
      {
        path: '',
        component: ReservaListComponent
      },
      /*{
        path: 'servicios/:id',
        component: ServiciosListComponent
      },
      {
        path: 'archivos/:id',
        component: ArchivosListComponent
      },*/
    ],
    canActivate: [AuthGuard]
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule, RouterModule.forChild(reservasRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class ReservasRoutingModule { }
