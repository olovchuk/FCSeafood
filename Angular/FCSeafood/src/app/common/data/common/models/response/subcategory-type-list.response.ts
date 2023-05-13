import {SubcategoryTModel} from "@common-data/common/models/common/subcategory-type.model";

export class SubcategoryTypeListResponse {
  isSuccessful: boolean = false;
  message: string = '';
  subcategoryTListModel: SubcategoryTModel[] = [];
}
