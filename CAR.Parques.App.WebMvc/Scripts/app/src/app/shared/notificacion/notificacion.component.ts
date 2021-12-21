import { Component, ViewEncapsulation } from '@angular/core';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition} from '@angular/material/snack-bar';

@Component({
  selector: 'app-notificacion',
  templateUrl: './notificacion.component.html',
  styleUrls: ['notificacion.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class NotificacionComponent {

  horizontalPosition: MatSnackBarHorizontalPosition = 'right';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';

  constructor(private _snackBar : MatSnackBar) {}

  openSnackBar(mensaje: string, tipo: string) {
    this._snackBar.open(mensaje, "Cerrar", {
      duration: 5000,
      horizontalPosition: this.horizontalPosition,
      verticalPosition: this.verticalPosition,
      panelClass: [tipo]
    })
  }
}
