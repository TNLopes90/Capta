import { Habilidade } from './Habilidade';
import { Time } from '@angular/common';

export class Jogador {
  jogadorId: number;
  nome: string;
  peso: number;
  altura: number;
  jogadorHabilidades: Habilidade[];
  time: Time;
}
