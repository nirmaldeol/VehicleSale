import { TestBed, inject } from '@angular/core/testing';

import { VehicalService } from './vehical.service';

describe('VehicalService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [VehicalService]
    });
  });

  it('should be created', inject([VehicalService], (service: VehicalService) => {
    expect(service).toBeTruthy();
  }));
});
