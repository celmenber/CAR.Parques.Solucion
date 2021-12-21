import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ParqueComponent } from './parque/parque.component';
import { Routes, RouterModule } from '@angular/router';
import { ServiciosListComponent } from './servicios-list/servicios-list.component';
import { ArchivosListComponent } from './archivos-list/archivos-list.component';
import { AuthGuard } from 'src/app/auth/auth.guard';

const parquesRoutes : Routes = [
  {
    path:'',
    children: [
      {
        path: '',
        component: ParqueComponent
      },
      {
        path: 'servicios/:id',
        component: ServiciosListComponent
      },
      {
        path: 'archivos/:id',
        component: ArchivosListComponent
      },
    ],
    canActivate: [AuthGuard]
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule, RouterModule.forChild(parquesRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class PaqueRoutingModule { }
