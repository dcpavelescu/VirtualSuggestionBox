import { Component, OnInit, Injectable } from '@angular/core';
import { Suggestion } from '../_models/Suggestion';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Http, Response } from '@angular/http';

@Component({
  selector: 'app-add-new-suggestion',
  templateUrl: './add-new-suggestion.component.html',
  styleUrls: ['./add-new-suggestion.component.css']
})

@Injectable()
export class AddNewSuggestionComponent implements OnInit {
  /**suggestion: Suggestion[];
  apiURL = 'https://localhost:44361/api/suggestion';

  Suggestion: Observable<Suggestion[]>; 

  constructor(private httpClient: HttpClient) { }

  getSuggestion() {
    return this.httpClient.get<Suggestion[]>(this.apiURL)
  }


  ngOnInit() {
    this.getSuggestion().subscribe(suggestion => this.suggestion = suggestion);
  }**/
  ngOnInit() { }
}
