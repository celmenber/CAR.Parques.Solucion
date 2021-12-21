import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GaleriareservasComponent } from './galeriareservas.component';

describe('GaleriareservasComponent', () => {
  let component: GaleriareservasComponent;
  let fixture: ComponentFixture<GaleriareservasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GaleriareservasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GaleriareservasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
