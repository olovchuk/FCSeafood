import { SubcategoryType } from "@common-enums/subcategory.type";

export class SubcategoryTModel {
  type: SubcategoryType = SubcategoryType.Unknown;
  name: string = '';
  imagePath: string = '';
}