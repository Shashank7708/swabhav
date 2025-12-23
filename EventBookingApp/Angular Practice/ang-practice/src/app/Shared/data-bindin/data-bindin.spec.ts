import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DataBindin } from './data-bindin';

describe('DataBindin', () => {
  let component: DataBindin;
  let fixture: ComponentFixture<DataBindin>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DataBindin]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DataBindin);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
