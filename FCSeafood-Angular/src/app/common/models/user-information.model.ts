import { RoleType } from "@common-enums/role.type";

export class UserInformationModel {
  firstName: string = '';
  lastName: string = '';
  email: string = '';
  role: RoleType = RoleType.Unregistered;
}
