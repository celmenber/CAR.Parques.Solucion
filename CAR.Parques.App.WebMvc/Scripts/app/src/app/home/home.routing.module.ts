import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

const homeRoutes : Routes = [
    {
        path: '',
        children: [
            {
                path:'',
                component: HomeComponent
            }
        ]
    }
];

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        RouterModule.forChild(homeRoutes)
    ],
    exports: [
        RouterModule
    ]
})

export class HomeRoutingModule {}