import { Injectable } from "@angular/core";
import { UserInformationData } from "@common-data/user-information/user-information.data";
import { UserIdRequest } from "@common-data/user-information/http/request/user-id.request";
import { UserModel } from "@common-models/user.model";
import { UpdateUserAddressRequest } from "@common-data/user-information/http/request/update-user-address.request";
import { UpdateUserInformationRequest } from "@common-data/user-information/http/request/update-user-information.request";
import { UserCredentialModel } from "@common-models/user-credential.model";
import { UpdateUserPasswordRequest } from "@common-data/user-information/http/request/update-user-password.request";

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

  async getCredentials(userIdRequest: UserIdRequest): Promise<UserCredentialModel | null> {
    const response = await this.userInformationData.getCredentials(userIdRequest);
    if (!response.isSuccessful)
      return null;

    return response.userCredentialModel;
  }

  async updateUserAddress(updateUserAddressRequest: UpdateUserAddressRequest): Promise<void> {
    await this.userInformationData.updateUserAddress(updateUserAddressRequest);
  }

  async updateUserInformation(updateUserInformationRequest: UpdateUserInformationRequest): Promise<void> {
    await this.userInformationData.updateUserInformation(updateUserInformationRequest);
  }

  async updateUserPassword(updateUserPasswordRequest: UpdateUserPasswordRequest): Promise<void> {
    await this.userInformationData.updateUserPassword(updateUserPasswordRequest);
  }
}
