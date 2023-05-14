import {CategoryTModel} from "@common-data/common/models/common/category-type.model";
import {SubcategoryTModel} from "@common-data/common/models/common/subcategory-type.model";

export class BindCategoryModel {
  categoryTModel: CategoryTModel = new CategoryTModel();
  subcategoryTModel: SubcategoryTModel = new SubcategoryTModel();
}
