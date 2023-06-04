import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CartPopup } from './cart.popup';

describe('CartComponent', () => {
  let popup: CartPopup;
  let fixture: ComponentFixture<CartPopup>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CartPopup]
    }).compileComponents();

    fixture = TestBed.createComponent(CartPopup);
    popup = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(popup).toBeTruthy();
  });
});
