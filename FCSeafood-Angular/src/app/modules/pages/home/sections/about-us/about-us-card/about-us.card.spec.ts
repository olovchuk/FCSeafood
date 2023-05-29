import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutUsCard } from './about-us.card';

describe('AboutUsCardComponent', () => {
  let card: AboutUsCard;
  let fixture: ComponentFixture<AboutUsCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AboutUsCard]
    }).compileComponents();

    fixture = TestBed.createComponent(AboutUsCard);
    card = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(card).toBeTruthy();
  });
});
