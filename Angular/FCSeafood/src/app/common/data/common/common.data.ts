import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {CommonDataSettings} from "@common-data/common/common.data.settings";
import {CategoryTListResponse} from "@common-data/common/models/response/get-category-type-list.response";
import {SubcategoryTypeListResponse} from "@common-data/common/models/response/subcategory-type-list.response";
import {firstValueFrom} from "rxjs";

@Injectable({providedIn: 'root'})
export class CommonData {
  constructor(private http: HttpClient,
              private settings: CommonDataSettings) {
  }

  async GetCategoryListAsync(): Promise<CategoryTListResponse> {
    return await firstValueFrom(this.http.get<CategoryTListResponse>(this.settings.getCategoryTList));
  }

  async GetSubCategoryListAsync(): Promise<SubcategoryTypeListResponse> {
    return await firstValueFrom(this.http.get<SubcategoryTypeListResponse>(this.settings.getSubcategoryTList))
  }
}
