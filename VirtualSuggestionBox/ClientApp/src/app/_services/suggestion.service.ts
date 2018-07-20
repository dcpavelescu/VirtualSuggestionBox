import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Suggestion } from '../_models/index';
import { environment } from '../../environments/environment';

@Injectable()
export class SuggestionService {
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Suggestion[]>(`${environment.apiUrl}/suggestion`);
  }
  getById(id: number) {
    return this.http.get(`${environment.apiUrl}/suggestion/` + id);
  }

  add(suggestion: Suggestion) {
    return this.http.post(`${environment.apiUrl}/suggestion/register`, suggestion);
  }

  update(suggestion: Suggestion) {
    return this.http.put(`${environment.apiUrl}/suggestion/` + suggestion.id, suggestion);
  }

  delete(id: number) {
    return this.http.delete(`${environment.apiUrl}/suggestion/` + id);
  }

}
