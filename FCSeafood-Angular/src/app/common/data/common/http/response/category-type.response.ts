import { CategoryTModel } from "@common-models/category-type.model";

export class CategoryTypeResponse {
  isSuccessful: boolean = false;
  message: string = '';
  categoryTModel: CategoryTModel = new CategoryTModel();
}
