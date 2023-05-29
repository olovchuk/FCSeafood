import { Injectable } from "@angular/core";
import { TokenModel } from "@common-models/token.model";


@Injectable({providedIn: 'root'})
export class AuthState {
  isAuthorized: boolean = false;
  token: TokenModel = new TokenModel();
}
