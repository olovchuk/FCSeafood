import {Injectable} from "@angular/core";
import {AppSettings} from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class CommonDataSettings {
  private _getCategoryTList: string = '/api/Common/GetCategoryTList';
  getCategoryTList: string = AppSettings.webApiHostUrl + this._getCategoryTList;

  private _getSubcategoryTList: string = '/api/Common/GetCategoryTList';
  getSubcategoryTList: string = AppSettings.webApiHostUrl + this._getSubcategoryTList;

  private _getSubcategoryByCategoryTList: string = '/api/Common/GetSubcategoryByCategoryTList';
  getSubcategoryByCategoryTList: string = AppSettings.webApiHostUrl + this._getSubcategoryByCategoryTList;

  private _getBindCategoryList: string = '/api/Common/GetBindCategoryList';
  getBindCategoryList: string = AppSettings.webApiHostUrl + this._getBindCategoryList;
}
