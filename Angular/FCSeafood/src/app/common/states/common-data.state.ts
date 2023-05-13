import {Injectable} from "@angular/core";
import {CategoryTModel} from "@common-data/common/models/common/category-type.model";
import {SubCategoryTModel} from "@common-data/common/models/common/sub-category-type.model";

@Injectable({providedIn: 'root'})
export class CommonDataState {
  categoryTListModel: CategoryTModel[] = [];
  subcategoryTListModel: SubCategoryTModel[] = [];

  ResolveInit: Function = new Function;
  Init = new Promise((resolve, reject) => {
    this.ResolveInit = resolve;
  })
}
