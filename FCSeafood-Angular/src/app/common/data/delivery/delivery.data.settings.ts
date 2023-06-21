import { Injectable } from "@angular/core";
import { AppSettings } from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class DeliveryDataSettings {
  private _insertDeliveryEndpoint: string = '/api/Delivery/InsertDelivery';
  insertDeliveryEndpoint: string = AppSettings.webApiHostUrl + this._insertDeliveryEndpoint;
}
