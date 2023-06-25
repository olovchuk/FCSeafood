import { UserCredentialModel } from "@common-models/user-credential.model";

export class CredentialResponse {
  isSuccessful: boolean = false;
  message: string = '';
  userCredentialModel: UserCredentialModel = new UserCredentialModel();
}
