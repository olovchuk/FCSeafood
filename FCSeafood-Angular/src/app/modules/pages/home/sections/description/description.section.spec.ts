import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DescriptionSection } from './description.section';

describe('DescriptionComponent', () => {
  let component: DescriptionSection;
  let fixture: ComponentFixture<DescriptionSection>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DescriptionSection]
    }).compileComponents();

    fixture = TestBed.createComponent(DescriptionSection);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
