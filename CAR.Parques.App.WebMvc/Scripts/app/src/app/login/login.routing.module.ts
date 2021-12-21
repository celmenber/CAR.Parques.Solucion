import { Routes, RouterModule } from "@angular/router";
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { RestablecerComponent } from "../usuario/restablecer/restablecer.component";

const loginRoutes : Routes = [
    {
        path: '',
        children: [
            {
                path:'',
                component: LoginComponent
            },
            {
                path: 'restablecer/:token',
                component: RestablecerComponent
            }
        ]
    }
];

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        RouterModule.forChild(loginRoutes)
    ],
    exports: [
        RouterModule
    ]
})

export class LoginRoutingModule {}