import { Component, Input } from '@angular/core';

@Component({
  selector: 'home-about-us-card',
  templateUrl: './about-us.card.html',
  styleUrls: ['./about-us.card.scss']
})
export class AboutUsCard {
  @Input("imgSrc") imgSrc!: string;
  @Input("title") title!: string;
  @Input("text") text!: string;
}
