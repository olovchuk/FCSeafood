import { Component, Input } from '@angular/core';
import { SubcategoryTModel } from "@common-models/subcategory-type.model";
import { RouteHelper } from "@common-helpers/route.helper";
import { ShopFiltersStateService } from "@common-services/shop-filters-state/shop-filters-state.service";
import { SubcategoryType } from "@common-enums/subcategory.type";

@Component({
  selector: 'shop-subcategory-type-card',
  templateUrl: './subcategory-type.card.html',
  styleUrls: ['./subcategory-type.card.scss']
})
export class SubcategoryTypeCard {
  @Input('subcategoryTModel') subcategoryTModel!: SubcategoryTModel;

  constructor(public routeHelper: RouteHelper,
              private shopFiltersStateService: ShopFiltersStateService) {
  }

  async goToItems(subcategoryType: SubcategoryType): Promise<void> {
    await this.shopFiltersStateService.changeSubcategory(subcategoryType);
    await this.routeHelper.goToItems();
  }
}
