import { TestBed } from '@angular/core/testing';

import { AccountDetailService } from './account-detail.service';

describe('AccountDetailService', () => {
  let service: AccountDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AccountDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
