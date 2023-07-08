import { Component } from '@angular/core';

@Component({
  selector: 'home-suppliers-section',
  templateUrl: './suppliers.section.html',
  styleUrls: ['./suppliers.section.scss', '../../home.component.scss']
})
export class SuppliersSection {
  suppliersList: string[];

  constructor() {
    this.suppliersList = [
      'China',
      'Argentina',
      'Norway',
      'Ukraine',
      'Spain',
      'Vietnam'
    ];
  }
}
