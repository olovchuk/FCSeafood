import { Injectable } from "@angular/core";
import { UserInformationData } from "@common-data/user-information/user-information.data";
import { UserIdRequest } from "@common-data/user-information/http/request/user-id.request";
import { UserModel } from "@common-models/user.model";
import { UpdateUserAddressRequest } from "@common-data/user-information/http/request/update-user-address.request";

@Injectable({providedIn: 'root'})
export class UserService {
  constructor(private userInformationData: UserInformationData) {
  }

  async getUser(userIdRequest: UserIdRequest): Promise<UserModel | null> {
    const response = await this.userInformationData.getUser(userIdRequest);
    if (!response.isSuccessful)
      return null;

    return response.userModel;
  }

  updateUserAddress(updateUserAddressRequest: UpdateUserAddressRequest): void {
    this.userInformationData.updateUserAddress(updateUserAddressRequest);
  }
}
