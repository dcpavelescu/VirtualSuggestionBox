import { Component, OnInit } from '@angular/core';
import { SuggestionService } from '../_services/suggestion.service';
import { Suggestion } from '../_models/Suggestion';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  private _suggestions : Suggestion[];

  constructor(private suggestionService: SuggestionService){}

  ngOnInit() {
    this.suggestionService.getAll().subscribe(suggestions => this._suggestions = suggestions);
    console.log(this._suggestions);
  }

}
