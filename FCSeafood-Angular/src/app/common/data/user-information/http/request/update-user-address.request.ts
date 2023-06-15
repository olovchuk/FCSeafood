import { AddressModel } from "@common-models/address.model";

export class UpdateUserAddressRequest {
  userId: string = ''; // Guid
  addressModel: AddressModel = new AddressModel();
}
