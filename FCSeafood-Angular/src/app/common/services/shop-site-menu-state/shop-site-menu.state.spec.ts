import { TestBed } from "@angular/core/testing";
import { ShopSiteMenuStateService } from './shop-site-menu-state.service';

describe('ShopSiteMenuStateService', () => {
  let service: ShopSiteMenuStateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShopSiteMenuStateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
