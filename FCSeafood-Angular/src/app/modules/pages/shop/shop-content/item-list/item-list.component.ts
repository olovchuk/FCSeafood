import { Component, OnDestroy, OnInit } from '@angular/core';
import { ItemService } from "@common-services/item.service";
import { ItemModel } from "@common-models/item.model";
import { ShopFiltersStateService } from "@common-services/shop-filters-state/shop-filters-state.service";
import { MatDialog } from "@angular/material/dialog";
import { FilterComponent } from "@modules-pages/shop/panels/filter/filter.component";
import { Subscription } from "rxjs";

@Component({
  selector: 'shop-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.scss']
})
export class ItemListComponent implements OnInit, OnDestroy {
  itemModels: ItemModel[] = [];

  applySubscription!: Subscription;

  constructor(private itemService: ItemService,
              private shopFiltersStateService: ShopFiltersStateService,
              private dialog: MatDialog) {
  }

  async ngOnInit(): Promise<void> {
    await this.applyFilters();
  }

  ngOnDestroy() {
    if (this.applySubscription)
      this.applySubscription.unsubscribe();
  }

  async applyFilters(): Promise<void> {
    this.itemModels = await this.itemService.getItemByFilterList(await this.shopFiltersStateService.getItemFilter());
  }

  openFiltersFullScreen() {
    const filterComponent = this.dialog.open(FilterComponent, {
      panelClass: ['animate__animated', 'animate__slideInUp', 'custom-container'],
      height: '100vh',
      width: '100vw'
    });
    filterComponent.componentInstance.isPopupFullScreen = true;
    this.applySubscription = filterComponent.componentInstance.applyEvent.subscribe(async () => {
      await this.applyFilters();
    });
  }
}
