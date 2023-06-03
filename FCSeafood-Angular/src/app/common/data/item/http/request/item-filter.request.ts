import { CategoryType } from "@common-enums/category.type";
import { SubcategoryType } from "@common-enums/subcategory.type";

export class ItemFilterRequest {
  categoryType: CategoryType = CategoryType.Unknown;
  subcategoryType: SubcategoryType = SubcategoryType.Unknown;
  priceFrom: number = -1;
  priceTo: number = -1;
}
