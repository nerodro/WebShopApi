import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductDetailsEditStatusComponent } from './product-details-edit-status.component';

describe('ProductDetailsEditStatusComponent', () => {
  let component: ProductDetailsEditStatusComponent;
  let fixture: ComponentFixture<ProductDetailsEditStatusComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProductDetailsEditStatusComponent]
    });
    fixture = TestBed.createComponent(ProductDetailsEditStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
