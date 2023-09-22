import { TestBed } from '@angular/core/testing';

import { ShopDetailService } from './shop-detail.service';

describe('ShopDetailService', () => {
  let service: ShopDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShopDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
