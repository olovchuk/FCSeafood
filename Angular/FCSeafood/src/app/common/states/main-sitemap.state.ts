import {Injectable} from "@angular/core";
import {MainMenuItemModel} from "@common-models/main-menu-item.model";

@Injectable({providedIn: 'root'})
export class MainSitemapState {
  items: MainMenuItemModel[] = [];
}
