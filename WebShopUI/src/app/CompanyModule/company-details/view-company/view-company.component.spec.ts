import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewCompanyComponent } from './view-company.component';

describe('ViewCompanyComponent', () => {
  let component: ViewCompanyComponent;
  let fixture: ComponentFixture<ViewCompanyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewCompanyComponent]
    });
    fixture = TestBed.createComponent(ViewCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
