import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { ItemDataSettings } from "@common-data/item/item.data.settings";
import { MessageHelper } from "@common-helpers/message.helper";
import { ItemResponse } from "@common-data/item/http/response/item.response";
import { ItemCodeRequest } from "@common-data/item/http/request/item-code.request";
import { ItemListResponse } from "@common-data/item/http/response/item-list.response";
import { ItemFilterRequest } from "@common-data/item/http/request/item-filter.request";

@Injectable({providedIn: 'root'})
export class ItemData {
  constructor(private http: HttpClient,
              private settings: ItemDataSettings,
              private messageHelper: MessageHelper) {
  }

  async getItemByCode(itemCodeRequest: ItemCodeRequest): Promise<ItemResponse> {
    let params = new HttpParams();
    params = params.append('Code', itemCodeRequest.code);

    const response = await firstValueFrom(this.http.get<ItemResponse>(this.settings.getItemByCodeEndpoint, {params: params}))
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }

  async getItemByFilterList(itemFilterRequest: ItemFilterRequest): Promise<ItemListResponse> {
    let params = new HttpParams();
    params = params.append('CategoryType', itemFilterRequest.categoryType);
    params = params.append('SubcategoryType', itemFilterRequest.subcategoryType);
    params = params.append('SortDirectionType', itemFilterRequest.sortDirectionType);
    params = params.append('PriceFrom', itemFilterRequest.priceFrom);
    params = params.append('PriceTo', itemFilterRequest.priceTo);

    const response = await firstValueFrom(this.http.get<ItemListResponse>(this.settings.getItemByFilterListEndpoint, {params: params}))
    if (!response.isSuccessful)
      this.messageHelper.error(response.message);

    return response;
  }
}
