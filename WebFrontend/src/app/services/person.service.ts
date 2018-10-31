import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Person } from '../models/person.model';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';

/**
 * Provides methods to receive person data from the WebApi
 */
@Injectable({
  providedIn: 'root'
})
export class PersonService {
  constructor(private http: Http) {}

  private personsUrl = 'https://localhost:44369/api/persons';

  getPersons(): Observable<Person[]> {
    return this.http.get(this.personsUrl).pipe(
      map(persons => {
        return persons.json() as Person[];
      })
    );
  }

  getPerson(id: number): Observable<Person> {
    return this.http.get(`${this.personsUrl}/${id}`).pipe(
      map(person => {
        return person.json() as Person;
      })
    );
  }
}
