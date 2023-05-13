import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FullSizeFilterComponent } from './full-size-filter.component';

describe('FullSizeFilterComponent', () => {
  let component: FullSizeFilterComponent;
  let fixture: ComponentFixture<FullSizeFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FullSizeFilterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FullSizeFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
