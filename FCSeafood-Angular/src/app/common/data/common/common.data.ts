import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { MessageHelper } from "@common-helpers/message.helper";
import { CommonDataSettings } from "@common-data/common/common.data.settings";
import { CategoryTListResponse } from "@common-data/common/http/response/category-type-list.response";
import { SubcategoryTRequest } from "@common-data/common/http/request/subcategory-type.request";
import { SubcategoryTListResponse } from "@common-data/common/http/response/subcategory-type-list.response";
import { CategoryTypeRequest } from "@common-data/common/http/request/category-type.request";
import { PaymentMethodTListResponse } from "@common-data/common/http/response/payment-method-type-list.response";
import { GenderTListResponse } from "@common-data/common/http/response/gender-type-list.response";
import { DeliveryStatusTListResponse } from "@common-data/common/http/response/delivery-status-type-list.response";

@Injectable({providedIn: 'root'})
export class CommonData {
  constructor(private http: HttpClient,
              private settings: CommonDataSettings,
              private messageHelper: MessageHelper) {
  }

  async getCategoryType(categoryTypeRequest: CategoryTypeRequest): Promise<CategoryTListResponse> {
    let params = new HttpParams();
    params = params.append('CategoryType', categoryTypeRequest.categoryType);

    const response = await firstValueFrom(this.http.get<CategoryTListResponse>(this.settings.getCategoryTEndpoint, {params: params}));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async getCategoryBySubcategoryType(subcategoryTRequest: SubcategoryTRequest): Promise<CategoryTListResponse> {
    let params = new HttpParams();
    params = params.append('SubcategoryType', subcategoryTRequest.subcategoryType);

    const response = await firstValueFrom(this.http.get<CategoryTListResponse>(this.settings.getCategoryBySubcategoryTEndpoint, {params: params}));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async getCategoryTList(): Promise<CategoryTListResponse> {
    const response = await firstValueFrom(this.http.get<CategoryTListResponse>(this.settings.getCategoryTListEndpoint));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async getSubcategoryTList(): Promise<SubcategoryTListResponse> {
    const response = await firstValueFrom(this.http.get<SubcategoryTListResponse>(this.settings.getSubcategoryTListEndpoint));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async getSubcategoryByCategoryTList(categoryTypeRequest: CategoryTypeRequest): Promise<SubcategoryTListResponse> {
    let params = new HttpParams();
    params = params.append('CategoryType', categoryTypeRequest.categoryType);

    const response = await firstValueFrom(this.http.get<SubcategoryTListResponse>(this.settings.getSubcategoryByCategoryTListEndpoint, {params: params}));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async getPaymentMethodTList(): Promise<PaymentMethodTListResponse> {
    const response = await firstValueFrom(this.http.get<PaymentMethodTListResponse>(this.settings.getPaymentMethodTListEndpoint));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async getGenderTList(): Promise<GenderTListResponse> {
    const response = await firstValueFrom(this.http.get<GenderTListResponse>(this.settings.getGenderTListEndpoint));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async getDeliveryStatusTList(): Promise<DeliveryStatusTListResponse> {
    const response = await firstValueFrom(this.http.get<DeliveryStatusTListResponse>(this.settings.getDeliveryStatusTListEndpoint));
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }
}
