import {JWTAuthModel} from "@common-models/jwtAuthModel";

export class SignInResponse {
  isSuccessful: boolean = false;
  message: string = '';
  jwtAuthModel: JWTAuthModel = new JWTAuthModel();
}
