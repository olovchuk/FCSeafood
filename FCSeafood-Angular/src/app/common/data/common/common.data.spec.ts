import { TestBed } from "@angular/core/testing";
import { CommonData } from './common.data';

describe('CommonData', () => {
  let data: CommonData;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    data = TestBed.inject(CommonData);
  });

  it('should be created', () => {
    expect(data).toBeTruthy();
  });
});
