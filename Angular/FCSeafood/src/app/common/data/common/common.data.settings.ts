import {Injectable} from "@angular/core";
import {AppSettings} from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class CommonDataSettings {
  private _getGetCategoryTypeList: string = '/api/Common/GetCategoryTypeList';
  geGetCategoryTypeList: string = AppSettings.webApiHostUrl + this._getGetCategoryTypeList;
}
