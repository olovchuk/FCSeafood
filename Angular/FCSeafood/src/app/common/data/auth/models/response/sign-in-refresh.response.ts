import {JWTAuthModel} from "@common-models/jwtAuthModel";

export class SignInRefreshResponse {
  isSuccessful: boolean = false;
  message: string = '';
  jwtAuthModel: JWTAuthModel = new JWTAuthModel();
}
