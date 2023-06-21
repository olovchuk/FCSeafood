import { UserInformationModel } from "@common-models/user-information.model";

export class UserInformationResponse {
  isSuccessful: boolean = false;
  message: string = '';
  userInformationModel: UserInformationModel = new UserInformationModel();
}
