import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryTypeCard } from './category-type.card';

describe('CategoryTypeComponent', () => {
  let card: CategoryTypeCard;
  let fixture: ComponentFixture<CategoryTypeCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CategoryTypeCard]
    }).compileComponents();

    fixture = TestBed.createComponent(CategoryTypeCard);
    card = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(card).toBeTruthy();
  });
});
