import {RoleType} from "../enums/role.type";

export class TokenModel {
  userId: string = '';
  email: string = '';
  roleType: RoleType = RoleType.Unregistered;
}
