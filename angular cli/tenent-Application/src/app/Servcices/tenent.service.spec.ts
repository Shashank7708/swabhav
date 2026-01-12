import { TestBed } from '@angular/core/testing';

import { TenentService } from './tenent.service';

describe('TenentService', () => {
  let service: TenentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TenentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
