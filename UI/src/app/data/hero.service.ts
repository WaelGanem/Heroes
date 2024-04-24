import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Hero } from '../hero';
import { catchError, tap } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class HeroService {
    private heroesUrl = 'http://localhost:5270/api/Heroes';  // Replace with your API base URL

    constructor(private http: HttpClient) {}

    getHeroes(): Observable<Hero[]> {
      return this.http.get<Hero[]>(this.heroesUrl).pipe(
          tap((heroes: Hero[]) => console.log('Fetched heroes: ', heroes)),  // Specify type
          catchError(this.handleError<Hero[]>('getHeroes', []))
      );
  }
  

    getHeroById(id: number): Observable<Hero> {
        const url = `<span class="math-inline">\{this\.heroesUrl\}/</span>{id}`;
        return this.http.get<Hero>(url).pipe(
            catchError(this.handleError<Hero>(`getHeroById id=${id}`))
        );
    }

    // TODO: Placeholder for error handling
    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
            console.error(error); 
            // TODO: Better error handling 
            return of(result as T);
        };
    }
}
