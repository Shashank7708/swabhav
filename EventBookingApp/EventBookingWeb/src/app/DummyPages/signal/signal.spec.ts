import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Signal } from './signal';

describe('Signal', () => {
  let component: Signal;
  let fixture: ComponentFixture<Signal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [Signal]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Signal);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
