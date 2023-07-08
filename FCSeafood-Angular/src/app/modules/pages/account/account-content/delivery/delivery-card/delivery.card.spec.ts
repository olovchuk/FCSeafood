import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeliveryCard } from './delivery.card';

describe('DeliveryCardComponent', () => {
  let component: DeliveryCard;
  let fixture: ComponentFixture<DeliveryCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeliveryCard ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeliveryCard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
