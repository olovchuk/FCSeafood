import { UserModel } from "@common-models/user.model";

export class UserResponse {
  isSuccessful: boolean = false;
  message: string = '';
  userModel: UserModel = new UserModel();
}
