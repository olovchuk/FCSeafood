import { TestBed } from "@angular/core/testing";
import { AuthStateService } from "@common-services/auth-state/auth-sate.service";

describe('AuthStateService', () => {
  let service: AuthStateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthStateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
