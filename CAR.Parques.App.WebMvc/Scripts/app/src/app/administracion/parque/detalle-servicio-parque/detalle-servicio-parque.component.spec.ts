import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalleServicioParqueComponent } from './detalle-servicio-parque.component';

describe('DetalleServicioParqueComponent', () => {
  let component: DetalleServicioParqueComponent;
  let fixture: ComponentFixture<DetalleServicioParqueComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalleServicioParqueComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalleServicioParqueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
