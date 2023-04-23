import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {CommonDataSettings} from "@common-data/common/common.data.settings";
import {GetCategoryTypeListResponse} from "@common-data/common/models/response/get-category-type-list.response";
import {firstValueFrom} from "rxjs";

@Injectable({providedIn: 'root'})
export class CommonData {
  constructor(private http: HttpClient,
              private settings: CommonDataSettings) {
  }

  async GetCategoryListAsync(): Promise<GetCategoryTypeListResponse> {
    return await firstValueFrom(this.http.get<GetCategoryTypeListResponse>(this.settings.geGetCategoryTypeList));
  }
}
