import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WhyUsCardComponent } from './why-us-card.component';

describe('WhyUsCardComponent', () => {
  let component: WhyUsCardComponent;
  let fixture: ComponentFixture<WhyUsCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WhyUsCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WhyUsCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
