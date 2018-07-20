import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
 
import { Suggestion } from '../_models/Suggestion';
import { SuggestionService } from '../_services/suggestion.service';

@Component({
  selector: 'app-suggestions-view',
  templateUrl: './suggestions-view.component.html',
  styleUrls: ['./suggestions-view.component.css']
})
export class SuggestionsViewComponent implements OnInit {
  suggestions: Suggestion[] = [];

  constructor(private suggestionService: SuggestionService) {
  }

  ngOnInit() {
      this.loadAllSuggestions();
  }

  deleteSuggestion(id: number) {

      this.suggestionService.delete(id).pipe(first()).subscribe(() => { 
          this.loadAllSuggestions() 
      });
  }

  private loadAllSuggestions() {
      this.suggestionService.getAll().pipe(first()).subscribe(suggestions => { 
          this.suggestions = suggestions; 
      });
  }
}
