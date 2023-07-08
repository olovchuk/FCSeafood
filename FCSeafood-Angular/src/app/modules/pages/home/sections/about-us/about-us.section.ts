import { Component } from '@angular/core';

@Component({
  selector: 'home-about-us-section',
  templateUrl: './about-us.section.html',
  styleUrls: ['./about-us.section.scss', '../../home.component.scss']
})
export class AboutUsSection {
  aboutCardsInfo: any;

  constructor() {
    this.aboutCardsInfo = [
      {imgSrc: 'assets/icons/shop-24.svg', title: 'Convenience', text: 'Customers can easily browse and purchase seafood products from the comfort of their own homes without the need to physically go to a store'},
      {imgSrc: 'assets/icons/filled-like.svg', title: 'Freshness', text: 'Fresh catch can offer a wider variety of fresh seafood products as they can source from different locations and have them delivered directly to customers'},
      {imgSrc: 'assets/icons/sale.svg', title: 'Competitive pricing', text: 'Fresh catch often have lower overhead costs and can pass on savings to customers with lower prices compared to brick-and-mortar stores'},
      {imgSrc: 'assets/icons/filled-info.svg', title: 'Easy access to information', text: 'Customers can easily access information about the seafood products they are interested in, including origin, catch method, and sustainability practices'},
      {imgSrc: 'assets/icons/filled-cart.svg', title: 'Wide selection', text: 'Fresh catch can offer a wider selection of seafood products compared to physical stores as they are not limited by physical space'},
      {imgSrc: 'assets/icons/filled-truck.svg', title: 'Fast and convenient delivery', text: 'Fresh Catch can offer fast and convenient delivery options, allowing customers to receive their orders at their doorstep without the need to travel to a store'}
    ];
  }
}
