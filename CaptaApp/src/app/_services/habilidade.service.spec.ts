/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { HabilidadeService } from './habilidade.service';

describe('Service: Habilidade', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HabilidadeService]
    });
  });

  it('should ...', inject([HabilidadeService], (service: HabilidadeService) => {
    expect(service).toBeTruthy();
  }));
});
