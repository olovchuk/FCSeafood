import {CategoryType} from "@common-enums/category.type";

export class CategoryTModel {
  type: CategoryType = CategoryType.Unknown;
  name: string = '';
  imagePath: string = '';
}
