import {Injectable} from "@angular/core";
import {HttpClient, HttpParams} from "@angular/common/http";
import {CommonDataSettings} from "@common-data/common/common.data.settings";
import {CategoryTListResponse} from "@common-data/common/models/response/category-type-list.response";
import {SubcategoryTypeListResponse} from "@common-data/common/models/response/subcategory-type-list.response";
import {firstValueFrom} from "rxjs";
import {CategoryType} from "@common-enums/category.type";
import {SubcategoryTypeRequest} from "@common-data/common/models/request/subcategory-type.request";

@Injectable({providedIn: 'root'})
export class CommonData {
  constructor(private http: HttpClient,
              private settings: CommonDataSettings) {
  }

  async GetCategoryListAsync(): Promise<CategoryTListResponse> {
    return await firstValueFrom(this.http.get<CategoryTListResponse>(this.settings.getCategoryTList));
  }

  async GetSubcategoryListAsync(): Promise<SubcategoryTypeListResponse> {
    return await firstValueFrom(this.http.get<SubcategoryTypeListResponse>(this.settings.getSubcategoryTList))
  }

  async GetSubcategoryByCategoryListAsync(subcategoryTypeRequest: SubcategoryTypeRequest): Promise<SubcategoryTypeListResponse> {
    let params = new HttpParams();
    params = params.append('CategoryType', subcategoryTypeRequest.categoryType);

    return await firstValueFrom(this.http.get<SubcategoryTypeListResponse>(this.settings.getSubcategoryByCategoryTList, {params: params}));
  }
}
