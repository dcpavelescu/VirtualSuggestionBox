import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewSuggestionComponent } from './add-new-suggestion.component';

describe('AddNewSuggestionComponent', () => {
  let component: AddNewSuggestionComponent;
  let fixture: ComponentFixture<AddNewSuggestionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddNewSuggestionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddNewSuggestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
