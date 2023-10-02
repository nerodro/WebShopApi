import { TestBed } from '@angular/core/testing';

import { CartDetailService } from './cart-detail.service';

describe('CartDetailService', () => {
  let service: CartDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CartDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
