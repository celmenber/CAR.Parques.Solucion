import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarServicioParqueComponent } from './editar-servicio-parque.component';

describe('EditarServicioParqueComponent', () => {
  let component: EditarServicioParqueComponent;
  let fixture: ComponentFixture<EditarServicioParqueComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditarServicioParqueComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarServicioParqueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
