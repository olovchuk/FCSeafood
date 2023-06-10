import { Injectable } from "@angular/core";
import { AppSettings } from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class OrderDataSettings {
  private _getOrderByUser: string = '/api/Order/GetOrderByUser';
  getOrderByUser: string = AppSettings.webApiHostUrl + this._getOrderByUser;
}
