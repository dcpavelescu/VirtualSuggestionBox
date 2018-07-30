import { Component, OnInit } from '@angular/core';
import { Suggestion } from '../_models/Suggestion';
import { SuggestionService } from '../_services/suggestion.service';


@Component({
  selector: 'app-recent-suggestion',
  templateUrl: './recent-suggestion.component.html',
  styleUrls: ['./recent-suggestion.component.css']
})
export class RecentSuggestionComponent implements OnInit {
  private suggestions: Suggestion[];

  constructor(private suggestionService: SuggestionService) { }

  ngOnInit() {
    this.suggestionService.getRecent().subscribe(suggestions => this.suggestions = suggestions);
  }
  calculateAverage(suggestions) {
    var sum = 0;
    var ratings = suggestions.ratings;
    if (ratings.length == 0) {
      return 0;
    }
    for (var i = 0; i < ratings.length; i++) {
      sum += parseInt(ratings[i], 10);
    }

    var avg = sum / ratings.length;

    return avg;
  }
}
