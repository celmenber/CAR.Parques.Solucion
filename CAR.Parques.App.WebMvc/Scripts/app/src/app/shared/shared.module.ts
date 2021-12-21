import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material/material.module';
import { NotificacionComponent } from './notificacion/notificacion.component';
import { CargadorComponent } from './cargador/cargador.component';
import { GrillaComponent } from './grilla/grilla.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { DatepickerComponent } from './datepicker/datepicker.component';
import { RenderHtmlComponent } from './render-html/render-html.component';
import { SlideComponent } from './slide/slide.component';



@NgModule({
  declarations: [NavBarComponent, NotFoundComponent, NotificacionComponent, CargadorComponent, GrillaComponent, DatepickerComponent, RenderHtmlComponent, SlideComponent],
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule,
    NgxDatatableModule
  ],
  exports: [
    NavBarComponent,
    NotFoundComponent,
    CargadorComponent,
    GrillaComponent,
    DatepickerComponent,
    SlideComponent
  ],
  providers: [NotificacionComponent],
  entryComponents: [DatepickerComponent]
})
export class SharedModule { }
