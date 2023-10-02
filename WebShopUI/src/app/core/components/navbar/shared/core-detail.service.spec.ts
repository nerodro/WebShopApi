import { TestBed } from '@angular/core/testing';

import { CoreDetailService } from './core-detail.service';

describe('CoreDetailService', () => {
  let service: CoreDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CoreDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
