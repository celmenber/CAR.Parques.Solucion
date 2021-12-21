import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalleServicioReservaComponent } from './detalle-servicio-reserva.component';

describe('DetalleServicioReservaComponent', () => {
  let component: DetalleServicioReservaComponent;
  let fixture: ComponentFixture<DetalleServicioReservaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalleServicioReservaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalleServicioReservaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
