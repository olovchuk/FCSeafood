import {Injectable} from "@angular/core";
import {CategoryTModel} from "@common-data/common/models/common/category-type.model";
import {SubcategoryTModel} from "@common-data/common/models/common/subcategory-type.model";
import {BindCategoryModel} from "@common-data/common/models/common/BindCategoryModel";

@Injectable({providedIn: 'root'})
export class CommonDataState {
  categoryTListModel: CategoryTModel[] = [];
  subcategoryTListModel: SubcategoryTModel[] = [];
  bindCategoryListModel: BindCategoryModel[] = [];

  ResolveInit: Function = new Function;
  Init = new Promise((resolve, reject) => {
    this.ResolveInit = resolve;
  })
}
