import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { MessageHelper } from "@common-helpers/message.helper";
import { UserInformationDataSettings } from "@common-data/user-information/user-information.data.settings";
import { UserInformationResponse } from "@common-data/user-information/http/response/user-information.response";
import { UserResponse } from "@common-data/user-information/http/response/user.response";
import { UserIdRequest } from "@common-data/user-information/http/request/user-id.request";
import { UpdateUserAddressRequest } from "@common-data/user-information/http/request/update-user-address.request";
import { UpdateUserInformationRequest } from "@common-data/user-information/http/request/update-user-information.request";

@Injectable({providedIn: 'root'})
export class UserInformationData {
  constructor(private http: HttpClient,
              private settings: UserInformationDataSettings,
              private messageHelper: MessageHelper) {
  }

  async getUser(userIdRequest: UserIdRequest): Promise<UserResponse> {
    let params = new HttpParams();
    params = params.append('UserId', userIdRequest.userId);

    const response = await firstValueFrom(this.http.get<UserResponse>(this.settings.getUserEndpoint, {params: params}));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async getUserInformation(): Promise<UserInformationResponse> {
    const response = await firstValueFrom(this.http.get<UserInformationResponse>(this.settings.getUserInformationEndpoint));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async updateUserAddress(updateUserAddressRequest: UpdateUserAddressRequest): Promise<void> {
    const response = await firstValueFrom(this.http.post(this.settings.updateUserAddressEndpoint, updateUserAddressRequest));
  }

  async updateUserInformation(updateUserInformationRequest: UpdateUserInformationRequest): Promise<void> {
    const response = await firstValueFrom(this.http.post(this.settings.updateUserInformationEndpoint, updateUserInformationRequest));
  }
}
