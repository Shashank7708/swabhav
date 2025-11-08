import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LifecycleEvent } from './lifecycle-event';

describe('LifecycleEvent', () => {
  let component: LifecycleEvent;
  let fixture: ComponentFixture<LifecycleEvent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LifecycleEvent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LifecycleEvent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
