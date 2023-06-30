import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeliveryFullInformationPopup } from './delivery-full-information.popup';

describe('DeliveyFullInformationComponent', () => {
  let component: DeliveryFullInformationPopup;
  let fixture: ComponentFixture<DeliveryFullInformationPopup>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeliveryFullInformationPopup ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeliveryFullInformationPopup);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
