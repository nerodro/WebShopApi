import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductDetailsFormComponent } from './product-details-form.component';

describe('ProductDetailsFormComponent', () => {
  let component: ProductDetailsFormComponent;
  let fixture: ComponentFixture<ProductDetailsFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProductDetailsFormComponent]
    });
    fixture = TestBed.createComponent(ProductDetailsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
