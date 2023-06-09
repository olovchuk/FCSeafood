import { Component, OnDestroy, OnInit } from '@angular/core';
import { RouteHelper } from "@common-helpers/route.helper";
import { ActivatedRoute } from "@angular/router";
import { ItemService } from "@common-services/item.service";
import { ItemModel } from "@common-models/item.model";
import { UiHelper } from "@common-helpers/ui.helper";
import { Subscription } from "rxjs";

@Component({
  selector: 'shop-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent implements OnInit, OnDestroy {
  protected readonly UiHelper = UiHelper;
  routeSubscription!: Subscription;

  item: ItemModel = new ItemModel();
  itemDetails: { name: string, value: string }[] = [];

  isKgQuantity: boolean = true;


  constructor(private routeHelper: RouteHelper,
              private route: ActivatedRoute,
              private itemService: ItemService) {
  }

  async ngOnInit(): Promise<void> {
    new Promise((resolve) => {
      this.routeSubscription = this.route.params.subscribe(async (params) => {
        if (!params['code']) {
          await this.routeHelper.goToError();
          return;
        }

        let item = await this.itemService.getItemByCode({code: params['code']});
        if (!item) {
          await this.routeHelper.goToError();
          return;
        }

        this.item = item;
        this.itemDetails.push({name: 'Brand', value: this.item.brand});
        this.itemDetails.push({name: 'Type', value: this.item.type});
        this.itemDetails.push({name: 'Fats /100g', value: this.item.fatsPer100Gram.toString()});
        this.itemDetails.push({name: 'Carbohydrates /100g', value: this.item.carbohydratesPer100Gram.toString()});
        this.itemDetails.push({name: 'Proteins /100g', value: this.item.proteinsPer100Gram.toString()});
        this.itemDetails.push({name: 'Kcal /100g', value: this.item.kcalPer100Gram.toString()});
        this.itemDetails.push({name: 'Humidity /%', value: this.item.humidityPerPercent.toString()});
        this.itemDetails.push({name: 'Expiration date', value: this.item.expirationDate.toString()});
        this.itemDetails.push({name: 'Temperature storage', value: this.item.temperatureStorage.toString() + ' ' + this.item.temperatureUnit.sign});
        resolve(null);
      });
    });
  }

  ngOnDestroy(): void {
    this.routeSubscription.unsubscribe();
  }
}
