import { Injectable } from "@angular/core";
import { AppSettings } from "@settings/app.settings";

@Injectable({providedIn: 'root'})
export class OrderDataSettings {
  private _insertOrderEntityEndpoint: string = '/api/Order/InsertOrderEntity';
  insertOrderEntityEndpoint: string = AppSettings.webApiHostUrl + this._insertOrderEntityEndpoint;

  private _getOrderByUserEndpoint: string = '/api/Order/GetOrderByUser';
  getOrderByUserEndpoint: string = AppSettings.webApiHostUrl + this._getOrderByUserEndpoint;

  private _getCompleteOrderListEndpoint: string = '/api/Order/GetCompleteOrderList';
  getCompleteOrderListEndpoint: string = AppSettings.webApiHostUrl + this._getCompleteOrderListEndpoint;

  private _getOrderCountByUserEndpoint: string = '/api/Order/GetOrderCountByUser';
  getOrderCountByUserEndpoint: string = AppSettings.webApiHostUrl + this._getOrderCountByUserEndpoint;

  private _removeOrderEntityEndpoint: string = '/api/Order/RemoveOrderEntity';
  removeOrderEntityEndpoint: string = AppSettings.webApiHostUrl + this._removeOrderEntityEndpoint;
}
