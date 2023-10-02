import { TestBed } from '@angular/core/testing';

import { CompanyDetailService } from './company-detail.service';

describe('CompanyDetailService', () => {
  let service: CompanyDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CompanyDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
