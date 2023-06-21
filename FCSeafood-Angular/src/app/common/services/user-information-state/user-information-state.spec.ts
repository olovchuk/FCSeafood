import { TestBed } from "@angular/core/testing";
import { UserInformationStateService } from "@common-services/user-information-state/user-information-state";

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
