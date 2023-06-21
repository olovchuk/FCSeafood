import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderMenu } from './header.menu';

describe('HeaderComponent', () => {
  let component: HeaderMenu;
  let fixture: ComponentFixture<HeaderMenu>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeaderMenu ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HeaderMenu);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
