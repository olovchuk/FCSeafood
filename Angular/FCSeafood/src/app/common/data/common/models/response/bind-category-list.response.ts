import {BindCategoryModel} from "@common-data/common/models/common/BindCategoryModel";

export class BindCategoryListResponse {
  isSuccessful: boolean = false;
  message: string = '';
  bindCategoryListModel: BindCategoryModel[] = [];
}
