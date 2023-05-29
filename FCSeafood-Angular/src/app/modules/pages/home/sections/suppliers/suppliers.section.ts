import { Component } from '@angular/core';

@Component({
  selector: 'home-suppliers-section',
  templateUrl: './suppliers.section.html',
  styleUrls: ['./suppliers.section.scss', '../../home.component.scss']
})
export class SuppliersSection {
  suppliersList: [];

  constructor() {
    this.suppliersList = [];
  }
}
