import { Injectable } from "@angular/core";
import { AppSettings } from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class ItemDataSettings {
  private _getItemByFilterList: string = '/api/Item/GetItemByFilterList';
  getItemByFilterList: string = AppSettings.webApiHostUrl + this._getItemByFilterList;
}
