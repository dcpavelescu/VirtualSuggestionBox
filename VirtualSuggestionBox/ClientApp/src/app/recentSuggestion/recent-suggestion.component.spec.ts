import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecentSuggestionComponent } from './recent-suggestion.component';

describe('RecentSuggestionComponent', () => {
  let component: RecentSuggestionComponent;
  let fixture: ComponentFixture<RecentSuggestionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecentSuggestionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecentSuggestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
