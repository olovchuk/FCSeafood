import { Injectable } from "@angular/core";
import { AppSettings } from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class ItemDataSettings {
  private _getItemByCode: string = '/api/Item/GetItemByCode';
  getItemByCode: string = AppSettings.webApiHostUrl + this._getItemByCode;

  private _getItemListByFilter: string = '/api/Item/GetItemListByFilter';
  getItemListByFilter: string = AppSettings.webApiHostUrl + this._getItemListByFilter;
}
