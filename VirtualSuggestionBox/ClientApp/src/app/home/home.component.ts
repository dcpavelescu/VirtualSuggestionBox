import { Component, OnInit } from '@angular/core';
import { SuggestionService } from '../_services/suggestion.service';
import { Suggestion } from '../_models/Suggestion';
import { Rate } from '../_models/Rate';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  private suggestions : Suggestion[];

  constructor(private suggestionService: SuggestionService){}

  ngOnInit() {
    this.suggestionService.getAll().subscribe(suggestions => this.suggestions = suggestions);
  }
  calculateAverage(suggestions){ 
    var sum = 0; 
    var ratings = suggestions.ratings;
    if(ratings.length== 0) {
      return 0;
    }
    for(var i = 0; i < ratings.length; i++) {
        sum += parseInt(ratings[i], 10);
    }

    var avg = sum/ratings.length;

    return avg; 
  }
}
