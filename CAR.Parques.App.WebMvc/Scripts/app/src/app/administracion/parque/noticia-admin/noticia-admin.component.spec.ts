import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NoticiaAdminComponent } from './noticia-admin.component';

describe('NoticiaAdminComponent', () => {
  let component: NoticiaAdminComponent;
  let fixture: ComponentFixture<NoticiaAdminComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NoticiaAdminComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NoticiaAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
