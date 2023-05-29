import { CategoryType } from "@common-enums/category.type";
import { SubcategoryTModel } from "@common-models/subcategory-type.model";

export class CategoryTModel {
  type: CategoryType = CategoryType.Unknown;
  name: string = '';
  imagePath: string = '';
  subcategoryTModelList: SubcategoryTModel[] = [];
}
