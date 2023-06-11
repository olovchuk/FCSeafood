import { Injectable } from "@angular/core";
import { AppSettings } from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class OrderDataSettings {
  private _getOrderByUser: string = '/api/Order/GetOrderByUser';
  getOrderByUser: string = AppSettings.webApiHostUrl + this._getOrderByUser;

  private _isExistsItemInOrder: string = '/api/Order/IsExistsItemInOrder';
  isExistsItemInOrder: string = AppSettings.webApiHostUrl + this._isExistsItemInOrder;

  private _insertOrderEntity: string = '/api/Order/InsertOrderEntity';
  insertOrderEntity: string = AppSettings.webApiHostUrl + this._insertOrderEntity;

  private _removeOrderEntity: string = '/api/Order/RemoveOrderEntity';
  removeOrderEntity: string = AppSettings.webApiHostUrl + this._removeOrderEntity;
}
