import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AdmUsuariosListComponent } from './adm-usuarios-list/adm-usuarios-list.component';
import { AuthGuard } from 'src/app/auth/auth.guard';

const usuariosRoutes : Routes = [
  {
    path: '', 
    children: [
      {
        path:'', 
        component: AdmUsuariosListComponent
      }
    ],
    canActivate: [AuthGuard]
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule, RouterModule.forChild(usuariosRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class UsuarioRoutingModule { 

}