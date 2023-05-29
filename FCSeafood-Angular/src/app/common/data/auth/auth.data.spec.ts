import { TestBed } from "@angular/core/testing";
import { AuthData } from './auth.data';

describe('AuthData', () => {
  let data: AuthData;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    data = TestBed.inject(AuthData);
  });

  it('should be created', () => {
    expect(data).toBeTruthy();
  });
});
