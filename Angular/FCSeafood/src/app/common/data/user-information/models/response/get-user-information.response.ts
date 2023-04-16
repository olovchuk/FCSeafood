import {UserInformationModel} from "@common-data/user-information/models/common/user-information.model";

export class GetUserInformationResponse {
  isSuccessful: boolean = false;
  message: string = '';
  userInformationModel: UserInformationModel = new UserInformationModel();
}
