import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material/material.module';
import { FileUploadComponent } from 'src/app/shared/file-upload/file-upload.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { NuevaNoticiaComponent } from './nueva-noticia/nueva-noticia.component';
import { NoticiaListComponent } from './noticia-list/noticia-list.component';
import { NgxEditorModule } from 'ngx-editor';
import { NoticiaRoutingModule } from './noticia-routing.module';

@NgModule({
  declarations: [NuevaNoticiaComponent, NoticiaListComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    SharedModule,
    NoticiaRoutingModule,
    NgxEditorModule,
  ],
  entryComponents: [],
})
export class NoticiaModule {}
