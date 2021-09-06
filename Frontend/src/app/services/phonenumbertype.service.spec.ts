import { TestBed } from '@angular/core/testing';

import { PhonenumbertypeService } from './phonenumbertype.service';

describe('PhonenumbertypeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PhonenumbertypeService = TestBed.get(PhonenumbertypeService);
    expect(service).toBeTruthy();
  });
});
