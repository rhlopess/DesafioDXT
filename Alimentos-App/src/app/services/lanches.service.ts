import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cardapio } from '../models/cardapio';
import { Ingrediente } from '../models/Ingrediente';

@Injectable({
  providedIn: 'root'
})
export class LanchesService {
  url = 'http://localhost:5001/api/values';
  constructor(private http: HttpClient) { }

  getLanches(): Observable<Cardapio[]> {
    return this.http.get<Cardapio[]>(this.url);
  }

  getIngredientes(): Observable<Ingrediente[]> {
    return this.http.get<Ingrediente[]>(`${this.url}/getIngredientes`);
  }

  getLancheById(id: number): Observable<Cardapio[]> {
    return this.http.get<Cardapio[]>(`${this.url}/${id}`);
  }

  postLanches(lanche: Cardapio) {
    return this.http.post<Cardapio[]>(`${this.url}`, lanche);
  }
}
