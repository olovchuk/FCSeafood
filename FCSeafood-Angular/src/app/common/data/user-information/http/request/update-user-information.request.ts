import { GenderType } from "@common-enums/gender.type";

export class UpdateUserInformationRequest {
  userId: string = ''; // Guid
  firstName: string = '';
  lastName: string = '';
  genderType: GenderType = GenderType.Unknown;
  phone: string | null = null;
  dateOfBirth: Date | null = null;
}
