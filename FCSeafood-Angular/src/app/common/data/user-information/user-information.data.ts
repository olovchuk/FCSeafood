import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { MessageHelper } from "@common-helpers/message.helper";
import { UserInformationDataSettings } from "@common-data/user-information/user-information.data.settings";
import { UserInformationResponse } from "@common-data/user-information/http/response/user-information.response";

@Injectable({providedIn: 'root'})
export class UserInformationData {
  constructor(private http: HttpClient,
              private settings: UserInformationDataSettings,
              private messageHelper: MessageHelper) {
  }

  async getUserInformation(): Promise<UserInformationResponse> {
    const response = await firstValueFrom(this.http.get<UserInformationResponse>(this.settings.getUserInformationEndpointUrl));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }
}
