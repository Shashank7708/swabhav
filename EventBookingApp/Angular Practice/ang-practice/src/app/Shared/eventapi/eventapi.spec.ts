import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Eventapi } from './eventapi';

describe('Eventapi', () => {
  let component: Eventapi;
  let fixture: ComponentFixture<Eventapi>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Eventapi]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Eventapi);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
