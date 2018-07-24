import { Component, OnInit } from '@angular/core';
import { SuggestionService } from '../_services/suggestion.service';
import { Suggestion } from '../_models/Suggestion';

@Component({
  selector: 'app-top3',
  templateUrl: './top3.component.html',
  styleUrls: ['./top3.component.css']
})
export class Top3Component implements OnInit {

  private suggestions : Suggestion[];

  constructor(private suggestionService: SuggestionService){}

  ngOnInit() {
    this.suggestionService.getTop3().subscribe(suggestions => this.suggestions = suggestions);
  }

}
