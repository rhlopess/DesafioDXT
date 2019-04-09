/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LanchesService } from './lanches.service';

describe('Service: Services', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LanchesService]
    });
  });

  it('should ...', inject([LanchesService], (service: LanchesService) => {
    expect(service).toBeTruthy();
  }));
});
