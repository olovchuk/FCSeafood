import { GenderTModel } from "@common-models/gender-type.model";

export class GenderTListResponse {
  isSuccessful: boolean = false;
  message: string = '';
  genderTListModel: GenderTModel[] = [];
}
