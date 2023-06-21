import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShopMenu } from './shop.menu';

describe('ShopSiteMenuComponent', () => {
  let component: ShopMenu;
  let fixture: ComponentFixture<ShopMenu>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShopMenu ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShopMenu);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
