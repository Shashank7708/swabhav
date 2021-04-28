import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TenentRegisterComponent } from './tenent-register.component';

describe('TenentRegisterComponent', () => {
  let component: TenentRegisterComponent;
  let fixture: ComponentFixture<TenentRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TenentRegisterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TenentRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
