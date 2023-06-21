import { RoleTModel } from "@common-models/role-type.model";
import { GenderTModel } from "@common-models/gender-type.model";
import { AddressModel } from "@common-models/address.model";

export class UserModel {
  id: string = ''; // guid
  firstName: string = '';
  lastName: string = '';
  email: string = '';
  role: RoleTModel = new RoleTModel();
  gender: GenderTModel = new GenderTModel();
  isActive: boolean = false;
  isVerified: boolean = false;
  phone: string | null = null;
  imagePath: string | null = null;
  dateOfBirth: Date | null = null;
  address: AddressModel | null = null;
  createdDate: Date = new Date();
  updatedDate: Date = new Date();
}
