import { Injectable } from "@angular/core";
import { AppSettings } from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class CommonDataSettings {
  private _getCategoryTEndpoint: string = '/api/Common/GetCategoryType';
  getCategoryTEndpoint: string = AppSettings.webApiHostUrl + this._getCategoryTEndpoint;

  private _getCategoryBySubcategoryTEndpoint: string = '/api/Common/GetCategoryBySubcategoryType';
  getCategoryBySubcategoryTEndpoint: string = AppSettings.webApiHostUrl + this._getCategoryBySubcategoryTEndpoint;

  private _getCategoryTListEndpoint: string = '/api/Common/GetCategoryTList';
  getCategoryTListEndpoint: string = AppSettings.webApiHostUrl + this._getCategoryTListEndpoint;

  private _getSubcategoryTListEndpoint: string = '/api/Common/GetCategoryTList';
  getSubcategoryTListEndpoint: string = AppSettings.webApiHostUrl + this._getSubcategoryTListEndpoint;

  private _getSubcategoryByCategoryTListEndpoint: string = '/api/Common/GetSubcategoryByCategoryTList';
  getSubcategoryByCategoryTListEndpoint: string = AppSettings.webApiHostUrl + this._getSubcategoryByCategoryTListEndpoint;
}
