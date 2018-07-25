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
  private allSuggestions: Suggestion[];

  constructor( private suggestionService: SuggestionService, private location: Location) { }
  
  public searchByAvgRate(): void {
    //this.suggestionService.getAll().subscribe(res => this.allSuggestions = res);
  }

  public searchByCategory(): void {
    //this.suggestionService.getAll().subscribe(res => this.allSuggestions = res);
  }

  goBack(): void {
    this.location.back();
  }
  
  ngOnInit() {

  }
  
}
