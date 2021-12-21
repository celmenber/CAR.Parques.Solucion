import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'src/app/auth/auth.guard';
import { NoticiaListComponent } from './noticia-list/noticia-list.component';
import { NuevaNoticiaComponent } from './nueva-noticia/nueva-noticia.component';

const parquesRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        component: NoticiaListComponent,
      },
      {
        path: 'Noticia',
        component: NuevaNoticiaComponent,
      },
    ],
    canActivate: [AuthGuard],
  },
];

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild(parquesRoutes)],
  exports: [RouterModule],
})
export class NoticiaRoutingModule {}
