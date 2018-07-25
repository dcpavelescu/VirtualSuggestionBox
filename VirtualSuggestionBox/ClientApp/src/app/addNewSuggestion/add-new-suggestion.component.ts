import { Component, OnInit, Injectable } from '@angular/core';
import { Suggestion } from '../_models/Suggestion';
import { SuggestionService } from '../_services/suggestion.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-add-new-suggestion',
  templateUrl: './add-new-suggestion.component.html',
  styleUrls: ['./add-new-suggestion.component.css']
})


export class AddNewSuggestionComponent implements OnInit {
  suggestion: Suggestion;
  list: [string];

  constructor(private suggestionService: SuggestionService,
    private location: Location) { }

  public save():void {
    console.log(this.suggestion);
    this.suggestionService.add(this.suggestion).subscribe(() => this.goBack());
  }

  public funct(value: string): void {
    this.list.push(value);
    this.suggestion.categories = this.list;
  }

  goBack(): void {
    this.location.back();
  }
    
  ngOnInit() {
    this.suggestion = new Suggestion();
  }
}
