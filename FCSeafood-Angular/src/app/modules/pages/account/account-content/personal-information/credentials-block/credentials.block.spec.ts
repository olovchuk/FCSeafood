import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CredentialsBlock } from './credentials.block';

describe('CredentialsBlockComponent', () => {
  let component: CredentialsBlock;
  let fixture: ComponentFixture<CredentialsBlock>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CredentialsBlock ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CredentialsBlock);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
