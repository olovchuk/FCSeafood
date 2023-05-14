import {ComponentFixture, TestBed} from '@angular/core/testing';

import {CategoryListPopupComponent} from './category-list-popup.component';

describe('CategoryListPopupComponent', () => {
  let component: CategoryListPopupComponent;
  let fixture: ComponentFixture<CategoryListPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CategoryListPopupComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(CategoryListPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
