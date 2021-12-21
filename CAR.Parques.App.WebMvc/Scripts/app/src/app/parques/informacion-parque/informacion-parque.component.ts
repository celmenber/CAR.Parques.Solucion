import { Component, Inject, OnInit, ElementRef } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { parque } from 'src/app/models/parques/parque';
import { parqueInformacion } from 'src/app/models/parques/parqueInformacion';
import { RenderHtmlComponent } from 'src/app/shared/render-html/render-html.component';

export interface DialogData {
  parque:parqueInformacion;
}

@Component({
  selector: 'app-informacion-parque',
  templateUrl: './informacion-parque.component.html',
  styleUrls: ['./informacion-parque.component.scss']
})
export class InformacionParqueComponent implements OnInit {
  _parque: parqueInformacion = new parqueInformacion();

  //_colorBase = { color: "" };
  ids: any = [
    { name: "Información", id: "info", hover: false, imagenSeccion:"https://parques.car.gov.co/imagenes/85041Vistaexterior2caba%C3%B1as2.jpg", cuerpo: "A 3.100 metros sobre el nivel del mar rodeado de bosque y plantaciones forestales de pino, eucalipto y bosque, emerge el Embalse del Neusa en un área de 3.700 hectáreas, en las que el promedio de temperatura fluctúa entre los 4º Y 23º centígrados. Es un destino ecológico que invita al descanso y esparcimiento.", fijo: false, esUbicacion: false},
    { name: "Horario", id: "horario", hover: false, imagenSeccion:"http://www.obcipol.com/wp-content/uploads/2015/11/SERVICIOS_DE_INGENIER%C3%8DA_AMBIENTAL_PARA_PARQUES.jpg", cuerpo:"<h3 class='page-header'>Horario</h3><strong>Horario de funcionamiento del parque:</strong><br>Recuerda que el <strong>primer día hábil de cada semana NO abrimos</strong>. Los demás días, puedes visitarnos de 8:30 AM a 4:00 PM<br><strong>Horario para alojamiento en cabañas:</strong><br>Ingreso (check in): 3:00 PM<br>Salida o (check out): 1:00 PM<br><strong>Horario para camping:</strong><br>Martes a jueves: 8:30 AM a 8:00 PM<br>Viernes, sábado y día anterior a festivo: 8:30 AM a 10:00 PM<br>", fijo: false, esUbicacion: false},
    { name: "Dato Adicional", id: "datoAdicional", hover: false, imagenSeccion:"https://parques.car.gov.co/imagenes/85041Vistaexterior2caba%C3%B1as2.jpg", cuerpo: "A 3.100 metros sobre el nivel del mar rodeado de bosque y plantaciones forestales de pino, eucalipto y bosque, emerge el Embalse del Neusa en un área de 3.700 hectáreas, en las que el promedio de temperatura fluctúa entre los 4º Y 23º centígrados. Es un destino ecológico que invita al descanso y esparcimiento.", fijo: false, esUbicacion: false},
    { name: "Dato Adicional 2", id: "datoAdicional2", hover: false, imagenSeccion:"https://parques.car.gov.co/imagenes/85041Vistaexterior2caba%C3%B1as2.jpg", cuerpo: "A 3.100 metros sobre el nivel del mar rodeado de bosque y plantaciones forestales de pino, eucalipto y bosque, emerge el Embalse del Neusa en un área de 3.700 hectáreas, en las que el promedio de temperatura fluctúa entre los 4º Y 23º centígrados. Es un destino ecológico que invita al descanso y esparcimiento.", fijo: false, esUbicacion: false},
    { name: "Conoce más", id: "concoceMas", hover: false, imagenSeccion:" ", cuerpo:"" , fijo: true, esUbicacion: false}, 
    { name: "Ubicación", id: "ubicacion", hover: false, imagenSeccion:"https://www.google.com/maps/embed?pb=!1m25!1m12!1m3!1d127242.2464334632!2d-74.23399315467168!3d4.714332579475338!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!4m10!3e0!4m3!3m2!1d4.5794858!2d-74.0976929!4m4!1s0x8e3f7f7fc5b8458f%3A0x6f2467551fea98a3!3m2!1d4.8527026!2d-74.2628356!5e0!3m2!1ses!2sco!4v1635219202865!5m2!1ses!2sco", cuerpo:"", fijo: true, esUbicacion: true}
  ];

  linksExternos: any = [
    { titulo: "Reglamento", descripcionCorta: "Reglamento parque", linkExterno: "https://parques.car.gov.co/PaginaWeb/PaginaEstatica/JuanPablo2/Reglamento.aspx", imagen: "https://parques.car.gov.co/imagenes/iconosFram/reglamento.png" }, 
    { titulo: "Mapa", descripcionCorta: "Mapa del Neusa", linkExterno: "https://parques.car.gov.co/mapasparques/web/parques/81/", imagen: "https://parques.car.gov.co/imagenes/mapa_icono_parque.png" }, 
    { titulo: "Tour 3D", descripcionCorta: "Vista 360°", linkExterno: "https://parques.car.gov.co/mapasparques/ServiciosMapas/api/parques/tours/81/type/parqueCompleto?index=0&action=redirect", imagen : "https://parques.car.gov.co/imagenes/icono_360_180x180.png" },
    { titulo: "Tour 4D", descripcionCorta: "Vista 360°", linkExterno: "https://parques.car.gov.co/mapasparques/ServiciosMapas/api/parques/tours/81/type/parqueCompleto?index=0&action=redirect", imagen : "https://parques.car.gov.co/imagenes/icono_360_180x180.png" }
  ];

  constructor(
    public dialogRef: MatDialogRef<InformacionParqueComponent>, @Inject(MAT_DIALOG_DATA) public data: DialogData, private route:ActivatedRoute, router: Router
  ) { 
    this._parque = data.parque;
    //this._parque.colorFondo = this.lightenDarkenColor(this._parque.Color,11);
    console.log(this._parque);
    //console.log(this.ids);
  }

  ngOnInit(): void {
  }

  lightenDarkenColor(col,amt) 
  { 
    var num = parseInt(col,16); 
    var r = (num >> 16) + amt; 
    var b = ((num >> 8) & 0x00FF) + amt; 
    var g = (num & 0x0000FF) + amt; 
    var newColor = g | (b << 8) | (r << 16);
    console.log(newColor);
    return  newColor.toString(16); 
  }

  ScrollIntoView(elem: string) {
    console.log(elem);
    document.querySelector(elem).scrollIntoView({ behavior: 'smooth', block: 'start' });
  }

  scroll($element) : void {
    console.log($element);
    $element.scrollIntoView({behavior: "smooth", block: "start", inline: "nearest"});
  }
}