import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CargadorService {

  estaCargando = new Subject<boolean>();
  mostrar() {
    this.estaCargando.next(true);
  }

  ocultar() {
    this.estaCargando.next(false);
  }
}
