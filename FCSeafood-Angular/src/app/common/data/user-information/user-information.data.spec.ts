import { TestBed } from "@angular/core/testing";
import { UserInformationData } from './user-information.data';

describe('UserInformationData', () => {
  let data: UserInformationData;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    data = TestBed.inject(UserInformationData);
  });

  it('should be created', () => {
    expect(data).toBeTruthy();
  });
});
