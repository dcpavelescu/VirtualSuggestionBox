import { Component, OnInit, Injectable } from '@angular/core';
import { Suggestion } from '../_models/Suggestion';
import { SuggestionService } from '../_services/suggestion.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-search-by-rate-category',
  templateUrl: './search-by-rate-category.component.html',
  styleUrls: ['./search-by-rate-category.component.css']
})


export class SearchByRateCategoryComponent implements OnInit {

  private suggestions: Suggestion[];

  // aici ar trebui sa fie datele din formular in loc de aceste atribute declarate
  private Categories: string[];
  private AvgRate: number;

  constructor( private suggestionService: SuggestionService, private location: Location) { }
  

  goBack(): void {
    this.location.back();
  }
  
  ngOnInit() {
    this.suggestionService.searchSuggestions(this.Categories, this.AvgRate).subscribe(suggestions => this.suggestions = suggestions);
  }
  
}
