import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Hero } from '../models/hero.model';
import { Superpoder } from '../models/superpoder.model';

@Injectable({
  providedIn: 'root'
})
export class HeroService {
  private apiUrl = 'http://localhost:5169/api/Herois'
  private superpowerApiUrl = 'http://localhost:5169/api/Superpoderes';
  
  constructor(private http: HttpClient) { }

  public getHeroes(): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.apiUrl);
  }

  public deleteHero(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  public getHeroByID(id: number): Observable<Hero> {
    return this.http.get<Hero>(`${this.apiUrl}/${id}`)
  }

  public getSuperpowers(): Observable<Superpoder[]> {
    return this.http.get<Superpoder[]>(this.superpowerApiUrl);
  }

  public createHero(heroData: any): Observable<Hero> {
    return this.http.post<Hero>(this.apiUrl, heroData);
  }

  // Novo método para atualizar um herói (PUT)
  public updateHero(id: number, heroData: any): Observable<Hero> {
    return this.http.put<Hero>(`${this.apiUrl}/${id}`, heroData);
  }
}
