import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemCardListCard } from './item-card-list.card';

describe('ItemCardListComponent', () => {
  let component: ItemCardListCard;
  let fixture: ComponentFixture<ItemCardListCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemCardListCard ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ItemCardListCard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
