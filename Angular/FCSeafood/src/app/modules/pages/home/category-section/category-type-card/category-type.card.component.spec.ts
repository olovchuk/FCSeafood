import {ComponentFixture, TestBed} from '@angular/core/testing';

import {CategoryTypeCardComponent} from './category-type.card.component';

describe('CategoryTypeCardComponent', () => {
  let component: CategoryTypeCardComponent;
  let fixture: ComponentFixture<CategoryTypeCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CategoryTypeCardComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(CategoryTypeCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
