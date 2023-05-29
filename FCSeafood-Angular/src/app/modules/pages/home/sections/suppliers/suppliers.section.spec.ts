import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuppliersSection } from './suppliers.section';

describe('SuppliersComponent', () => {
  let component: SuppliersSection;
  let fixture: ComponentFixture<SuppliersSection>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SuppliersSection]
    }).compileComponents();

    fixture = TestBed.createComponent(SuppliersSection);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
