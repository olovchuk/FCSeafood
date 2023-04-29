import {CategoryTModel} from "@common-data/common/models/common/category-type.model";

export class CategoryTListResponse {
  isSuccessful: boolean = false;
  message: string = '';
  categoryTModels: CategoryTModel[] = [];
}
