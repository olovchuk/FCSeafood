import {SubCategoryTModel} from "@common-data/common/models/common/sub-category-type.model";

export class SubcategoryTypeListResponse {
  isSuccessful: boolean = false;
  message: string = '';
  subcategoryTListModel: SubCategoryTModel[] = [];
}
