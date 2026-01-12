import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Photos } from './photos';

describe('Photos', () => {
  let component: Photos;
  let fixture: ComponentFixture<Photos>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [Photos]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Photos);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
