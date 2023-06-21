import { TestBed } from "@angular/core/testing";
import { OrderData } from './order.data';

describe('OrderData', () => {
  let data: OrderData;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    data = TestBed.inject(OrderData);
  });

  it('should be created', () => {
    expect(data).toBeTruthy();
  });
});
