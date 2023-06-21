import { SubcategoryTModel } from "@common-models/subcategory-type.model";

export class SubcategoryTListResponse {
  isSuccessful: boolean = false;
  message: string = '';
  subcategoryTListModel: SubcategoryTModel[] = [];
}