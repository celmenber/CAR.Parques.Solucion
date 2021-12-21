import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmUsuariosListComponent } from './adm-usuarios-list.component';

describe('AdmUsuariosListComponent', () => {
  let component: AdmUsuariosListComponent;
  let fixture: ComponentFixture<AdmUsuariosListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdmUsuariosListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdmUsuariosListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
