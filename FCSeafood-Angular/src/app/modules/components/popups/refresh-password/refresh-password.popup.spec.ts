import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RefreshPasswordPopup } from './refresh-password.popup';

describe('RefreshPasswordComponent', () => {
  let component: RefreshPasswordPopup;
  let fixture: ComponentFixture<RefreshPasswordPopup>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RefreshPasswordPopup ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RefreshPasswordPopup);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
