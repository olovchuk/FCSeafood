import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderItemCard } from './order-item.card';

describe('OrderItemCardComponent', () => {
  let component: OrderItemCard;
  let fixture: ComponentFixture<OrderItemCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderItemCard ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderItemCard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
