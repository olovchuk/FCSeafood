import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddressBlock } from './address.block';

describe('AddressBlockComponent', () => {
  let component: AddressBlock;
  let fixture: ComponentFixture<AddressBlock>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddressBlock ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddressBlock);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
