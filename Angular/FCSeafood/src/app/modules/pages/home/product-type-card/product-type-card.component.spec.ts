import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductTypeCardComponent } from './product-type-card.component';

describe('ProductTypeCardComponent', () => {
  let component: ProductTypeCardComponent;
  let fixture: ComponentFixture<ProductTypeCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductTypeCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductTypeCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
