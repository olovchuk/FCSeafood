import {TestBed} from "@angular/core/testing";
import {CommonDataStateService} from './common-data-state.service';

describe('CommonDataStateService', () => {
  let service: CommonDataStateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CommonDataStateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
