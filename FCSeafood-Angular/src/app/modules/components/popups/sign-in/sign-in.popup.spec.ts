import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignInPopup } from './sign-in.popup';

describe('SignInPopup', () => {
  let popup: SignInPopup;
  let fixture: ComponentFixture<SignInPopup>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SignInPopup]
    }).compileComponents();

    fixture = TestBed.createComponent(SignInPopup);
    popup = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(popup).toBeTruthy();
  });
});
