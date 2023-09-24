import { TestBed } from '@angular/core/testing';

import { UserDetailService } from './user-detail.service';

describe('ShopDetailService', () => {
  let service: UserDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
