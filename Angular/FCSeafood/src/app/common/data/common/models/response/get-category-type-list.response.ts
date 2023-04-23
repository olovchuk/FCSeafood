import {CategoryTypeModel} from "@common-data/common/models/common/category-type.model";

export class GetCategoryTypeListResponse {
  isSuccessful: boolean = false;
  message: string = '';
  categoryTypeModels: CategoryTypeModel[] = [];
}
