import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignUpPopup } from './sign-up.popup';

describe('SignUpPopup', () => {
  let popup: SignUpPopup;
  let fixture: ComponentFixture<SignUpPopup>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SignUpPopup]
    }).compileComponents();

    fixture = TestBed.createComponent(SignUpPopup);
    popup = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(popup).toBeTruthy();
  });
});
