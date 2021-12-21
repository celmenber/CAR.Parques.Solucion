import { Component, OnInit } from '@angular/core';
import {ThemePalette} from '@angular/material/core';
import {ProgressSpinnerMode} from '@angular/material/progress-spinner';
import { Subject } from 'rxjs';
import { CargadorService } from '../../servicios/shared/cargador.service'

@Component({
  selector: 'app-cargador',
  templateUrl: './cargador.component.html',
  styleUrls: ['./cargador.component.scss']
})
export class CargadorComponent {

  constructor(private CargadorService: CargadorService) { }

  color: ThemePalette = 'accent';
  mode: ProgressSpinnerMode = 'indeterminate';
  mostrarCargador: Subject<boolean> = this.CargadorService.estaCargando;
  
}
