import { CategoryType } from "@common-enums/category.type";
import { SubcategoryType } from "@common-enums/subcategory.type";
import { SortDirectionType } from "@common-enums/sort-direction.type";

export class ItemFilterRequest {
  categoryType: CategoryType = CategoryType.Unknown;
  subcategoryType: SubcategoryType = SubcategoryType.Unknown;
  sortDirectionType: SortDirectionType = SortDirectionType.NoSort;
  priceFrom: number = -1;
  priceTo: number = -1;
}
