import { JWTAuthModel } from "@common-models/jwt-auth.model";

export class SignInResponse {
  isSuccessful: boolean = false;
  message: string = '';
  jwtAuthModel: JWTAuthModel = new JWTAuthModel();
}