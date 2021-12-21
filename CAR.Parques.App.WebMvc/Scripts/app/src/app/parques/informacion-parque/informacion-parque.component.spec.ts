import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InformacionParqueComponent } from './informacion-parque.component';

describe('InformacionParqueComponent', () => {
  let component: InformacionParqueComponent;
  let fixture: ComponentFixture<InformacionParqueComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InformacionParqueComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InformacionParqueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
