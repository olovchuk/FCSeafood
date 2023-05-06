import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FirstPurchaseSectionComponent } from './first-purchase.section.component';

describe('FirstPurchaseSectionComponent', () => {
  let component: FirstPurchaseSectionComponent;
  let fixture: ComponentFixture<FirstPurchaseSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FirstPurchaseSectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FirstPurchaseSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
