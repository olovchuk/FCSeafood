import { Injectable } from "@angular/core";
import { AppSettings } from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class OrderDataSettings {
  private _insertOrderEntityEndpoint: string = '/api/Order/InsertOrderEntity';
  insertOrderEntityEndpoint: string = AppSettings.webApiHostUrl + this._insertOrderEntityEndpoint;

  private _isExistsItemInOrderEndpoint: string = '/api/Order/IsExistsItemInOrder';
  isExistsItemInOrderEndpoint: string = AppSettings.webApiHostUrl + this._isExistsItemInOrderEndpoint;

  private _getOrderByUserEndpoint: string = '/api/Order/GetOrderByUser';
  getOrderByUserEndpoint: string = AppSettings.webApiHostUrl + this._getOrderByUserEndpoint;

  private _removeOrderEntityEndpoint: string = '/api/Order/RemoveOrderEntity';
  removeOrderEntityEndpoint: string = AppSettings.webApiHostUrl + this._removeOrderEntityEndpoint;
}
