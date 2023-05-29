import { Injectable } from "@angular/core";
import { CategoryType } from "@common-enums/category.type";
import { CategoryTModel } from "@common-models/category-type.model";
import { SubcategoryType } from "@common-enums/subcategory.type";
import { SubcategoryTModel } from "@common-models/subcategory-type.model";
import { SortDirectionType } from "@common-enums/sort-direction.type";
import { SortDirectionTModel } from "@common-models/sort-direction-type.model";

@Injectable({providedIn: 'root'})
export class ShopFiltersState {
  categoryTList: CategoryTModel[] = [];
  selectedCategoryType: CategoryType = CategoryType.Unknown;
  subcategoryTList: SubcategoryTModel[] = [];
  selectedSubcategoryType: SubcategoryType = SubcategoryType.Unknown;
  sortDirectionTList: SortDirectionTModel[] = [];
  selectedPriceSortDirectionType: SortDirectionType = SortDirectionType.Ascending;

  ResolveInit: Function = new Function;
  Init = new Promise((resolve, reject) => {
    this.ResolveInit = resolve;
  })
}
