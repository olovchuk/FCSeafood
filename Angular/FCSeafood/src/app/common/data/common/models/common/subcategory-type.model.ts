import {SubcategoryType} from "@common-enums/sub-category.type";


export class SubcategoryTModel {
  type: SubcategoryType = SubcategoryType.Unknown;
  name: string = '';
  imagePath: string = '';
}
