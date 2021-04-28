import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UseRegisterComponent } from './use-register.component';

describe('UseRegisterComponent', () => {
  let component: UseRegisterComponent;
  let fixture: ComponentFixture<UseRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UseRegisterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UseRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
