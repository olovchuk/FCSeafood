import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchasesCard } from './purchases.card';

describe('PurchasesCardComponent', () => {
  let component: PurchasesCard;
  let fixture: ComponentFixture<PurchasesCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PurchasesCard ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PurchasesCard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
