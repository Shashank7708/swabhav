import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateForm } from './template-form';

describe('TemplateForm', () => {
  let component: TemplateForm;
  let fixture: ComponentFixture<TemplateForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TemplateForm]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TemplateForm);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
