import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FirstPurchaseSection } from './first-purchase.section';

describe('FirstPurchaseComponent', () => {
  let component: FirstPurchaseSection;
  let fixture: ComponentFixture<FirstPurchaseSection>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FirstPurchaseSection]
    }).compileComponents();

    fixture = TestBed.createComponent(FirstPurchaseSection);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
