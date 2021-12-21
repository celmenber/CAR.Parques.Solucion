import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ParquesListComponent } from './parques-list.component';

describe('ParquesListComponent', () => {
  let component: ParquesListComponent;
  let fixture: ComponentFixture<ParquesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ParquesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ParquesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
