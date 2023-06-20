import { Injectable } from "@angular/core";
import { AppSettings } from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class ItemDataSettings {
  private _getItemByCodeEndpoint: string = '/api/Item/GetItemByCode';
  getItemByCodeEndpoint: string = AppSettings.webApiHostUrl + this._getItemByCodeEndpoint;

  private _getItemByFilterListEndpoint: string = '/api/Item/GetItemByFilterList';
  getItemByFilterListEndpoint: string = AppSettings.webApiHostUrl + this._getItemByFilterListEndpoint;

  private _getItemRatingEndpoint: string = '/api/Item/GetItemRating';
  getItemRatingEndpoint: string = AppSettings.webApiHostUrl + this._getItemRatingEndpoint;

  private _setItemRatingEndpoint: string = '/api/Item/SetItemRating';
  setItemRatingEndpoint: string = AppSettings.webApiHostUrl + this._setItemRatingEndpoint;
}
