import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NuevoServicioParqueComponent } from './nuevo-servicio-parque.component';

describe('NuevoServicioParqueComponent', () => {
  let component: NuevoServicioParqueComponent;
  let fixture: ComponentFixture<NuevoServicioParqueComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NuevoServicioParqueComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NuevoServicioParqueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
