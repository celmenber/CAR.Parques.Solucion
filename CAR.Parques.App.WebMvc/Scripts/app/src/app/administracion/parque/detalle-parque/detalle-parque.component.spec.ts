import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalleParqueComponent } from './detalle-parque.component';

describe('DetalleParqueComponent', () => {
  let component: DetalleParqueComponent;
  let fixture: ComponentFixture<DetalleParqueComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalleParqueComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalleParqueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
