import { TestBed } from "@angular/core/testing";
import { DeliveryData } from './delivery.data';

describe('DeliveryData', () => {
  let data: DeliveryData;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    data = TestBed.inject(DeliveryData);
  });

  it('should be created', () => {
    expect(data).toBeTruthy();
  });
});
