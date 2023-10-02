import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductDetailsAllviewComponent } from './product-details-allview.component';

describe('ProductDetailsAllviewComponent', () => {
  let component: ProductDetailsAllviewComponent;
  let fixture: ComponentFixture<ProductDetailsAllviewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProductDetailsAllviewComponent]
    });
    fixture = TestBed.createComponent(ProductDetailsAllviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
