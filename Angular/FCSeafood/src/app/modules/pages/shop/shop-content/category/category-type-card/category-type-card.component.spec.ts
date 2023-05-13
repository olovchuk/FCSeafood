import {ComponentFixture, TestBed} from '@angular/core/testing';
import {CategoryTypeCardShopComponent} from "@modules/pages/shop/shop-content/category/category-type-card/category-type-card.component";

describe('CategoryTypeCardShopComponent', () => {
  let component: CategoryTypeCardShopComponent;
  let fixture: ComponentFixture<CategoryTypeCardShopComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CategoryTypeCardShopComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(CategoryTypeCardShopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
