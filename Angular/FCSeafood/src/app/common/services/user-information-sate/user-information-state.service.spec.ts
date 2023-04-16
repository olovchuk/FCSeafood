import {TestBed} from "@angular/core/testing";
import {UserInformationStateService} from './user-information-state.service';

describe('UserInformationStateService', () => {
  let service: UserInformationStateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserInformationStateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
