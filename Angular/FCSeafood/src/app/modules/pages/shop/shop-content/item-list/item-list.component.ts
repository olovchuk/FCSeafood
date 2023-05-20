import {Component, OnInit} from '@angular/core';
import {ShopFiltersStateService} from "@common-services/shop-filters-state/shop-filters-state.service";

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.scss']
})
export class ItemListComponent implements OnInit {
  title: string = '';

  constructor(private shopFiltersStateService: ShopFiltersStateService) {
  }

  async ngOnInit(): Promise<void> {
    console.log(this.shopFiltersStateService.state.selectedCategoryType);
    console.log(this.shopFiltersStateService.state.selectedSubcategoryType);
  }
}
