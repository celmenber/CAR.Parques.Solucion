import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NuevoParqueComponent } from './nuevo-parque.component';

describe('NuevoParqueComponent', () => {
  let component: NuevoParqueComponent;
  let fixture: ComponentFixture<NuevoParqueComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NuevoParqueComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NuevoParqueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
