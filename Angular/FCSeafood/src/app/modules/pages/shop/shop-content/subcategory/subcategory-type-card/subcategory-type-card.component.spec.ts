import {ComponentFixture, TestBed} from '@angular/core/testing';

import {SubcategoryTypeCardComponent} from './subcategory-type-card.component';

describe('SubcategoryTypeCardComponent', () => {
  let component: SubcategoryTypeCardComponent;
  let fixture: ComponentFixture<SubcategoryTypeCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SubcategoryTypeCardComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(SubcategoryTypeCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
