import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { Suggestion } from '../_models/Suggestion';
import { Observable } from 'rxjs';



const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


@Injectable({
  providedIn: 'root'
})
export class SuggestionService {
  constructor(private http: HttpClient) { }

  private serviceURL = "http://localhost:52763/api/suggestion";

  getAll(): Observable<Suggestion[]> {
    return this.http.get<Suggestion[]>(this.serviceURL);
  }

  getById(id: number) {
    return this.http.get(this.serviceURL + id);
  }

  add(suggestion: Suggestion): Observable<Suggestion> {
    return this.http.post<Suggestion>(this.serviceURL, suggestion, httpOptions);
  }


  update(suggestion: Suggestion) {
    return this.http.put<Suggestion>(this.serviceURL + suggestion.id, suggestion, httpOptions);
  }

  delete(id: number) {
    return this.http.delete(this.serviceURL + id);
  }

  getTop3(): Observable<Suggestion[]> {
    return this.http.get<Suggestion[]>(`${environment.apiUrl}/api/suggestion/top3`);
  }
}
