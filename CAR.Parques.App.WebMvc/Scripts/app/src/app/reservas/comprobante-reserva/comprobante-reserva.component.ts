import {
  ChangeDetectorRef,
  Component,
  Inject,
  OnInit,
  TemplateRef,
  ViewChild,
} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { archivoReserva } from 'src/app/models/reservas/archivoReserva';
import { ReservaService } from 'src/app/servicios/reservas/reservas.service';
import { GrillaComponent } from 'src/app/shared/grilla/grilla.component';
import { NotificacionComponent } from 'src/app/shared/notificacion/notificacion.component';

@Component({
  selector: 'app-comprobante-reserva',
  templateUrl: './comprobante-reserva.component.html',
  styleUrls: ['./comprobante-reserva.component.scss'],
})
export class ComprobanteReservaComponent implements OnInit {
  comprobantePagoForm: FormGroup;
  reservaId: number = 0;

  //Objetos para Carga de Imagen
  public respuestaImagenEnviada;
  public resultadoCarga;
  public nombreArchivo = 'Seleccione archivo ...';
  public archivoCargado: boolean = false;
  public archivoComprobante: File;

  @ViewChild('tableView') tableView: GrillaComponent<any>;
  @ViewChild('reservaIdTemplate') private reservaIdTemplate: TemplateRef<any>;
  @ViewChild('AccionesTemplate') private accionesTemplate: TemplateRef<any>;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private reservaService: ReservaService,
    private appBase: NotificacionComponent,
    public dialogRef: MatDialogRef<ComprobanteReservaComponent>
  ) {}

  ngOnInit(): void {
    this.reservaId = this.data.reservaId;
    console.log('Id Reserva Server' + this.data.reservaId);
    this.construirNuevoArchivoFormulario();
  }

  construirNuevoArchivoFormulario(): void {
    this.comprobantePagoForm = this.fb.group({});
  }

  cargarArchivo(event: any): void {
    this.archivoComprobante = event.target.files[0];
    console.log(this.archivoComprobante);
    this.nombreArchivo = this.archivoComprobante.name;
    this.archivoCargado = true;
  }

  guardar(): void {
    if (this.comprobantePagoForm.valid) {
      this.construirObjetoImagen();
    } else if (!this.comprobantePagoForm.dirty) {
      this.comprobantePagoForm.reset();
    }
  }

  public construirObjetoImagen(): void {
    let tituloArchivo = `Comprobante-Reserva-${this.reservaId}`;

    const archivoReserva: archivoReserva = {
      archivoReservaId: 0,
      reservaId: this.reservaId,
      tituloArchivoReserva: tituloArchivo,
      byteArchivo: this.archivoComprobante,
    };
    //debugger;
    console.log(archivoReserva)
    this.reservaService
      .cargarComprobanteReserva(archivoReserva)
      .subscribe((response: any) => {
        console.log(response.Entidad.Entidad);
        if (response.Codigo == 200 && response.Entidad.Entidad !== 0) {
          this.appBase.openSnackBar(
            'Se cargó el archivo con éxito.',
            'exito-notificacion'
          );
        } else {
          this.appBase.openSnackBar(
            'Se presento un error, por favor comuniquese con el administrador del sistema.',
            'error-notificacion'
          );
        }
      });
  }
}
