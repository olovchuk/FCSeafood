import {Injectable} from "@angular/core";
import {AppSettings} from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class CommonDataSettings {
  private _getCategoryTList: string = '/api/Common/GetCategoryTList';
  getCategoryTList: string = AppSettings.webApiHostUrl + this._getCategoryTList;

  private _getSubCategoryByCategoryTList: string = '/api/Common/GetSubCategoryByCategoryTList';
  getSubCategoryByCategoryTList: string = AppSettings.webApiHostUrl + this._getSubCategoryByCategoryTList;
}
