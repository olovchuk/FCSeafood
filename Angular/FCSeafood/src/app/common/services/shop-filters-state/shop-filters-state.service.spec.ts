import {TestBed} from "@angular/core/testing";
import {ShopFiltersStateService} from './shop-filters-state.service';

describe('ShopFiltersStateService', () => {
  let service: ShopFiltersStateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShopFiltersStateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
