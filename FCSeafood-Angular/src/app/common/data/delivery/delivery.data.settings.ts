import { Injectable } from "@angular/core";
import { AppSettings } from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class DeliveryDataSettings {
  private _insertDeliveryEndpoint: string = '/api/Delivery/InsertDelivery';
  insertDeliveryEndpoint: string = AppSettings.webApiHostUrl + this._insertDeliveryEndpoint;

  private _getDeliveryListEndpoint: string = '/api/Delivery/GetDeliveryList';
  getDeliveryListEndpoint: string = AppSettings.webApiHostUrl + this._getDeliveryListEndpoint;
}
