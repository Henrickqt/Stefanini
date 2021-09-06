import { TestBed } from '@angular/core/testing';

import { PersonphoneService } from './personphone.service';

describe('PersonphoneService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PersonphoneService = TestBed.get(PersonphoneService);
    expect(service).toBeTruthy();
  });
});
