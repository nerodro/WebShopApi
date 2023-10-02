import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyDetailsComponent } from './company-details.component';

describe('CompanyDetailsComponent', () => {
  let component: CompanyDetailsComponent;
  let fixture: ComponentFixture<CompanyDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CompanyDetailsComponent]
    });
    fixture = TestBed.createComponent(CompanyDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
