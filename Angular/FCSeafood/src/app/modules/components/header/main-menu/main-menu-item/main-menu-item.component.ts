import {Component, ElementRef, Input} from '@angular/core';
import {MainMenuItemModel} from "@common-models/main-menu-item.model";
import {MatDialog} from "@angular/material/dialog";

@Component({
  selector: 'header-main-menu-item',
  templateUrl: './main-menu-item.component.html',
  styleUrls: ['./main-menu-item.component.scss']
})
export class MainMenuItemComponent {
  @Input('item') item!: MainMenuItemModel;

  constructor(private elementRef: ElementRef,
              private dialog: MatDialog) {
  }

  onItemClick(): void {
    const componentElement: HTMLElement = this.elementRef.nativeElement;
    const posX = componentElement.offsetLeft + 'px';
    const posY = (componentElement.offsetTop + 25) + 'px';

    this.dialog.open(this.item.popup, {
      position: {top: posY, left: posX},
      maxWidth: '300px',
      maxHeight: '560px'
    });
  }
}
