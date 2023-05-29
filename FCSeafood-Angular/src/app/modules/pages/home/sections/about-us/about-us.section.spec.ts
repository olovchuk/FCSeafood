import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutUsSection } from './about-us.section';

describe('AboutUsComponent', () => {
  let component: AboutUsSection;
  let fixture: ComponentFixture<AboutUsSection>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AboutUsSection]
    }).compileComponents();

    fixture = TestBed.createComponent(AboutUsSection);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
