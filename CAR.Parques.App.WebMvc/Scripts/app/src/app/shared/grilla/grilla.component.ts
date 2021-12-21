import { Component, OnInit, Input, TemplateRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-grilla',
  templateUrl: './grilla.component.html',
  styleUrls: ['./grilla.component.scss']
})
export class GrillaComponent<T> implements OnInit {

  @Input() minTableHeight: number = 200;
  @Input() items: object[] = [];
  @Input() columns: object[] = [];
  @Input() limit?: number;
  @Input() detailTemplate: TemplateRef<any>;//Para enviar HTML a un componente generico.

  @ViewChild('myTable') table: any;// Captura el id del DOM

  constructor() { }

  ngOnInit(): void { 
  }

  toggleExpandRow(row) {
    this.table.rowDetail.toggleExpandRow(row);
  }
}
