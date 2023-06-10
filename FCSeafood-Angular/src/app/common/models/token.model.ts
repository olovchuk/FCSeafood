import { RoleType } from "@common-enums/role.type";

export class TokenModel {
  UserId: string = '';
  Email: string = '';
  RoleType: RoleType = RoleType.Unregistered;
}
