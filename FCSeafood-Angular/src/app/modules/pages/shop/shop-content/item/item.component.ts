import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { RouteHelper } from "@common-helpers/route.helper";
import { ActivatedRoute } from "@angular/router";
import { ItemService } from "@common-services/item.service";
import { OrderStateService } from "@common-services/order-state/order-state.service";
import { OrderEntityModel } from "@common-models/order-entity.model";
import { ItemModel } from "@common-models/item.model";
import { UiHelper } from "@common-helpers/ui.helper";
import { Subscription } from "rxjs";
import { InputNumber } from "primeng/inputnumber";
import { RatingType } from "@common-enums/rating.type";
import { AuthStateService } from "@common-services/auth-state/auth-sate.service";

@Component({
  selector: 'shop-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent implements OnInit, OnDestroy {
  @ViewChild("quantityValue") quantityValue!: InputNumber;

  protected readonly UiHelper = UiHelper;
  protected readonly RatingType = RatingType;
  routeSubscription!: Subscription;

  item: ItemModel = new ItemModel();
  itemDetails: { name: string, value: string }[] = [];

  userRating: RatingType | null = null;
  isKgQuantity: boolean = true;
  likeCount: number = 0.0;
  dislikeCount: number = 0.0;

  constructor(private routeHelper: RouteHelper,
              private route: ActivatedRoute,
              private itemService: ItemService,
              private orderStateService: OrderStateService,
              private authStateService: AuthStateService) {
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
        this.likeCount = this.item.likeCount;
        this.dislikeCount = this.item.dislikeCount;
        this.itemDetails.push({name: 'Brand', value: this.item.brand});
        this.itemDetails.push({name: 'Type', value: this.item.type});
        this.itemDetails.push({name: 'Fats /100g', value: this.item.fatsPer100Gram.toString()});
        this.itemDetails.push({name: 'Carbohydrates /100g', value: this.item.carbohydratesPer100Gram.toString()});
        this.itemDetails.push({name: 'Proteins /100g', value: this.item.proteinsPer100Gram.toString()});
        this.itemDetails.push({name: 'Kcal /100g', value: this.item.kcalPer100Gram.toString()});
        this.itemDetails.push({name: 'Humidity /%', value: this.item.humidityPerPercent.toString()});
        this.itemDetails.push({name: 'Expiration date', value: this.item.expirationDate.toString()});
        this.itemDetails.push({name: 'Temperature storage', value: this.item.temperatureStorage.toString() + ' ' + this.item.temperatureUnit.sign});

        if (this.authStateService.token.UserId)
          this.userRating = await this.itemService.getRatingByUser({userId: this.authStateService.token.UserId});
        resolve(null);
      });
    });
  }

  ngOnDestroy(): void {
    this.routeSubscription.unsubscribe();
  }

  async addToCart(): Promise<void> {
    if (!this.item)
      return;

    let price = 0.0;
    let quantityPerKg = 0.0;
    if (this.quantityValue.value && this.quantityValue.value > 0) {
      quantityPerKg = this.quantityValue.value;
      if (!this.isKgQuantity)
        quantityPerKg = (quantityPerKg / 1000);

      price = this.item.price * quantityPerKg;
    }

    let orderEntity: OrderEntityModel = {
      id: UiHelper.GUID_EMPTY,
      item: this.item,
      quantityPerKg: quantityPerKg,
      price: price
    };
    await this.orderStateService.insertOrderEntity(orderEntity);
  }

  async setRating(ratingType: RatingType): Promise<void> {
    this.userRating = ratingType;
  }

  async shopNow(): Promise<void> {
    await this.addToCart();
    await this.routeHelper.goToPayment();
  }
}
