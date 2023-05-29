import { Injectable } from "@angular/core";
import { CommonData } from "@common-data/common/common.data";
import { CategoryType } from "@common-enums/category.type";
import { CategoryTModel } from "@common-models/category-type.model";
import { SubcategoryTModel } from "@common-models/subcategory-type.model";
import { CategoryTypeRequest } from "@common-data/common/http/request/category-type.request";


@Injectable({providedIn: 'root'})
export class CommonService {
  constructor(private commonData: CommonData) {
  }

  async getCategoryTListAsync(): Promise<CategoryTModel[]> {
    const response = await this.commonData.getCategoryTList();
    if (!response.isSuccessful)
      return [];

    return response.categoryTListModel;
  }

  async getSubcategoryTListAsync(category: CategoryType): Promise<SubcategoryTModel[]> {
    let categoryTypeRequest: CategoryTypeRequest = {
      categoryType: category
    };

    const response = await this.commonData.getSubcategoryByCategoryTList(categoryTypeRequest);
    if (!response.isSuccessful)
      return [];

    return response.subcategoryTListModel;
  }
}
