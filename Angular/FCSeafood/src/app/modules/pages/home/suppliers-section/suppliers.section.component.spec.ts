import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuppliersSectionComponent } from './suppliers.section.component';

describe('SuppliersSectionComponent', () => {
  let component: SuppliersSectionComponent;
  let fixture: ComponentFixture<SuppliersSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SuppliersSectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SuppliersSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
