import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { MessageHelper } from "@common-helpers/message.helper";
import { CommonDataSettings } from "@common-data/common/common.data.settings";
import { CategoryTListResponse } from "@common-data/common/http/response/category-type-list.response";
import { SubcategoryTRequest } from "@common-data/common/http/request/subcategory-type.request";
import { SubcategoryTListResponse } from "@common-data/common/http/response/subcategory-type-list.response";
import { CategoryTypeRequest } from "@common-data/common/http/request/category-type.request";

@Injectable({providedIn: 'root'})
export class CommonData {
  constructor(private http: HttpClient,
              private settings: CommonDataSettings,
              private messageHelper: MessageHelper) {
  }

  async getCategoryType(categoryTypeRequest: CategoryTypeRequest): Promise<CategoryTListResponse> {
    let params = new HttpParams();
    params = params.append('CategoryType', categoryTypeRequest.categoryType);

    const response = await firstValueFrom(this.http.get<CategoryTListResponse>(this.settings.getCategoryType, {params: params}));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async getCategoryBySubcategoryType(subcategoryTRequest: SubcategoryTRequest): Promise<CategoryTListResponse> {
    let params = new HttpParams();
    params = params.append('SubcategoryType', subcategoryTRequest.subcategoryType);

    const response = await firstValueFrom(this.http.get<CategoryTListResponse>(this.settings.getCategoryBySubcategoryType, {params: params}));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async getCategoryTList(): Promise<CategoryTListResponse> {
    const response = await firstValueFrom(this.http.get<CategoryTListResponse>(this.settings.getCategoryTList));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async getSubcategoryTList(): Promise<SubcategoryTListResponse> {
    const response = await firstValueFrom(this.http.get<SubcategoryTListResponse>(this.settings.getSubcategoryTList));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async getSubcategoryByCategoryTList(categoryTypeRequest: CategoryTypeRequest): Promise<SubcategoryTListResponse> {
    let params = new HttpParams();
    params = params.append('CategoryType', categoryTypeRequest.categoryType);

    const response = await firstValueFrom(this.http.get<SubcategoryTListResponse>(this.settings.getSubcategoryByCategoryTList, {params: params}));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }
}
