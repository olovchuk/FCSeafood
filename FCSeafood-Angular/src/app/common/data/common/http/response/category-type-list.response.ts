import { CategoryTModel } from "@common-models/category-type.model";

export class CategoryTListResponse {
  isSuccessful: boolean = false;
  message: string = '';
  categoryTListModel: CategoryTModel[] = [];
}