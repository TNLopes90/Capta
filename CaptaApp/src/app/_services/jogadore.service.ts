import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Jogador } from '../_models/Jogador';

@Injectable({
  providedIn: 'root'
})

export class JogadoreService {

  baseURL = 'https://localhost:5001/api/jogador';
  constructor(private http: HttpClient) { }

}
