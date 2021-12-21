import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NuevoDescuentoServicioComponent } from './nuevo-descuento-servicio.component';

describe('NuevoDescuentoServicioComponent', () => {
  let component: NuevoDescuentoServicioComponent;
  let fixture: ComponentFixture<NuevoDescuentoServicioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NuevoDescuentoServicioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NuevoDescuentoServicioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
