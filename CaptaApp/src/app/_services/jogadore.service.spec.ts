/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { JogadoreService } from './jogadore.service';

describe('Service: Jogadore', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [JogadoreService]
    });
  });

  it('should ...', inject([JogadoreService], (service: JogadoreService) => {
    expect(service).toBeTruthy();
  }));
});
