import { TestBed } from '@angular/core/testing';

import { ServicioparqueService } from './servicioparque.service';

describe('ServicioparqueService', () => {
  let service: ServicioparqueService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServicioparqueService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
