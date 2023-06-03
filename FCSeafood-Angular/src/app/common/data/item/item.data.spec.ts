import { ItemData } from './item.data';
import { TestBed } from "@angular/core/testing";

describe('ItemData', () => {
  let data: ItemData;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    data = TestBed.inject(ItemData);
  });

  it('should be created', () => {
    expect(data).toBeTruthy();
  });
});
