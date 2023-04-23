import {CategoryType} from "@common-enums/category.type";

export class CategoryTypeModel {
  type: CategoryType = CategoryType.Unknown;
  name: string = '';
  imagePath: string = '';
}
