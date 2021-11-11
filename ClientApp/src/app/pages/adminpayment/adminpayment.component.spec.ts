import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminpaymentComponent } from './adminpayment.component';

describe('AdminpaymentComponent', () => {
  let component: AdminpaymentComponent;
  let fixture: ComponentFixture<AdminpaymentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminpaymentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminpaymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
