import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowfavouriteComponent } from './showfavourite.component';

describe('ShowfavouriteComponent', () => {
  let component: ShowfavouriteComponent;
  let fixture: ComponentFixture<ShowfavouriteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowfavouriteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowfavouriteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
