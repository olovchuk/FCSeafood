import { Injectable } from "@angular/core";

@Injectable({providedIn: 'root'})
export class ShopSiteMenuState {
  menuItems: { text: string, href: string }[] = [];
}
