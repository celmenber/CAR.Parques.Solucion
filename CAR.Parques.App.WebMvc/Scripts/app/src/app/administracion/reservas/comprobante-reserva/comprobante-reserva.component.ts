import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef,MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ArchivoReservaService } from 'src/app/servicios/reservas/archivoReserva.service';
import { ReservaService } from 'src/app/servicios/reservas/reservas.service';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';


@Component({
  selector: 'app-comprobante-reserva',
  templateUrl: './comprobante-reserva.component.html',
  styleUrls: ['./comprobante-reserva.component.scss']
})
export class ComprobanteReservaComponent implements OnInit {
  reservaId: number;
  comprobante: any = { imagenComprobante: '' };

  estadosReserva: any = {
    aprobado: 3,
    rechazado: 4
  }

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private archivoReservaService: ArchivoReservaService, 
    private reservaService: ReservaService,
    private appBase: NotificacionComponent,
    private dialogRef: MatDialogRef<ComprobanteReservaComponent>
  ) { }

  ngOnInit(): void {
    this.reservaId = this.data.reservaId; 
    this.obtenerArchivoReserva();   
  }

  obtenerArchivoReserva(): void {    
    this.archivoReservaService.obtenerArchivosReserva(this.reservaId)
      .subscribe(
        response => {
          //debugger;
          if(response.Entidad.Entidad !== null){
          var comprobanteReserva = response.Entidad.Entidad;          
            if (comprobanteReserva !== undefined) {
              let bytes = comprobanteReserva.ByteArchivo;
              let imagenComprobante = 'data:image/jpeg;base64,' + bytes;
              comprobanteReserva.imagenComprobante = imagenComprobante;
              this.comprobante = comprobanteReserva;
            }
          }else {  this.appBase.openSnackBar("Aún NO hay recibo cargado por el usuario.","error-notificacion"); }
        },
        error => {
          var x = error;
        }
      );
  }

  aprobarReserva():void{     
    this.cambiarEstadoReserva(this.estadosReserva.aprobado, "Reserva aprobada");
  }

  rechazarReserva():void{    
    this.cambiarEstadoReserva(this.estadosReserva.rechazado, "Reserva rechazada");
  }

  cambiarEstadoReserva(estadoReserva: number, mensaje: string):void{
    
    this.reservaService.establecerEstadoReserva( {ReservaId: this.reservaId, EstadoId: estadoReserva}).subscribe(
      response => {
        response.Entidad.Entidad;
        if(response.Codigo == 200)
        {
          this.appBase.openSnackBar("Se actualizo el estado con éxito.", "exito-notificacion");
        }
        else
        {
          this.appBase.openSnackBar("Falla en la actualización del estado de la reserva, intente nuevamente o comuniquese con el administrador del sistema.","error-notificacion");
        }
        alert(mensaje);
      }
    );
    this.dialogRef.close({});
  }

}
