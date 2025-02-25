import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainSection } from './main.section';

describe('MainSectionComponent', () => {
  let component: MainSection;
  let fixture: ComponentFixture<MainSection>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MainSection]
    }).compileComponents();

    fixture = TestBed.createComponent(MainSection);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
