import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarDescuentoServicioComponent } from './editar-descuento-servicio.component';

describe('EditarDescuentoServicioComponent', () => {
  let component: EditarDescuentoServicioComponent;
  let fixture: ComponentFixture<EditarDescuentoServicioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditarDescuentoServicioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarDescuentoServicioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
