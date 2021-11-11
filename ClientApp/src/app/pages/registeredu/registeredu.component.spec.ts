import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistereduComponent } from './registeredu.component';

describe('RegistereduComponent', () => {
  let component: RegistereduComponent;
  let fixture: ComponentFixture<RegistereduComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegistereduComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistereduComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
