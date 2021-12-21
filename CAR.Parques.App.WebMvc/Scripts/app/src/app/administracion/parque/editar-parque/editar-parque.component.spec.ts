import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarParqueComponent } from './editar-parque.component';

describe('EditarParqueComponent', () => {
  let component: EditarParqueComponent;
  let fixture: ComponentFixture<EditarParqueComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditarParqueComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarParqueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
