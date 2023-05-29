import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubcategoryTypeCard } from './subcategory-type.card';

describe('SubcategoryTypeCardComponent', () => {
  let component: SubcategoryTypeCard;
  let fixture: ComponentFixture<SubcategoryTypeCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubcategoryTypeCard ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SubcategoryTypeCard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
