import { Injectable } from "@angular/core";
import { CommonData } from "@common-data/common/common.data";
import { CategoryType } from "@common-enums/category.type";
import { CategoryTModel } from "@common-models/category-type.model";
import { SubcategoryTModel } from "@common-models/subcategory-type.model";
import { CategoryTypeRequest } from "@common-data/common/http/request/category-type.request";
import { PaymentMethodTModel } from "@common-models/payment-method-type.model";
import { GenderTModel } from "@common-models/gender-type.model";
import { DeliveryStatusTModel } from "@common-models/delivery-status-type.model";


@Injectable({providedIn: 'root'})
export class CommonService {
  constructor(private commonData: CommonData) {
  }

  async getCategoryTList(): Promise<CategoryTModel[]> {
    const response = await this.commonData.getCategoryTList();
    if (!response.isSuccessful)
      return [];

    return response.categoryTListModel;
  }

  async getSubcategoryTList(category: CategoryType): Promise<SubcategoryTModel[]> {
    let categoryTypeRequest: CategoryTypeRequest = {
      categoryType: category
    };

    const response = await this.commonData.getSubcategoryByCategoryTList(categoryTypeRequest);
    if (!response.isSuccessful)
      return [];

    return response.subcategoryTListModel;
  }

  async getPaymentMethodTList(): Promise<PaymentMethodTModel[]> {
    const response = await this.commonData.getPaymentMethodTList();
    if (!response.isSuccessful)
      return [];

    return response.paymentMethodTListModel;
  }

  async getGenderTList(): Promise<GenderTModel[]> {
    const response = await this.commonData.getGenderTList();
    if (!response.isSuccessful)
      return [];

    return response.genderTListModel;
  }

  async getDeliveryStatusTList(): Promise<DeliveryStatusTModel[]> {
    const response = await this.commonData.getDeliveryStatusTList();
    if (!response.isSuccessful)
      return [];

    return response.deliveryStatusTListModel;
  }
}
