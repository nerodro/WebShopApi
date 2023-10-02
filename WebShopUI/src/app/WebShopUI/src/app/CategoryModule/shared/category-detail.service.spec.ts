import { TestBed } from '@angular/core/testing';

import { CategoryDetailService } from './category-detail.service';

describe('CategoryDetailService', () => {
  let service: CategoryDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategoryDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
