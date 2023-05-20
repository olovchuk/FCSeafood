import {Injectable} from "@angular/core";
import {CategoryTModel} from "@common-data/common/models/common/category-type.model";
import {SubcategoryTModel} from "@common-data/common/models/common/subcategory-type.model";
import {CategoryType} from "@common-enums/category.type";
import {SubcategoryType} from "@common-enums/sub-category.type";
import {SortDirectionType} from "@common-enums/sort-direction.type";

@Injectable({providedIn: 'root'})
export class ShopFiltersState {
  categoryTList: CategoryTModel[] = [];
  selectedCategoryType: CategoryType = CategoryType.Unknown;
  subcategoryTList: SubcategoryTModel[] = [];
  selectedSubcategoryType: SubcategoryType = SubcategoryType.Unknown;
  sortDirectionTList: SortDirectionType[] = [];
  selectedPriceSorted: SortDirectionType = SortDirectionType.Descending;

  ResolveInit: Function = new Function;
  Init = new Promise((resolve) => {
    this.ResolveInit = resolve;
  })
}
