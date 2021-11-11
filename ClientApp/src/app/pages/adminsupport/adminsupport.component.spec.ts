import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminsupportComponent } from './adminsupport.component';

describe('AdminsupportComponent', () => {
  let component: AdminsupportComponent;
  let fixture: ComponentFixture<AdminsupportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminsupportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminsupportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
