import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputTextAreaPopup } from './input-text-area.popup';

describe('InputTextAreaComponent', () => {
  let component: InputTextAreaPopup;
  let fixture: ComponentFixture<InputTextAreaPopup>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InputTextAreaPopup ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputTextAreaPopup);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
