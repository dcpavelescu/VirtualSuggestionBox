import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchByRateCategoryComponent } from './search-by-rate-category.component';

describe('SearchByRateCategoryComponent', () => {
  let component: SearchByRateCategoryComponent;
  let fixture: ComponentFixture<SearchByRateCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [SearchByRateCategoryComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchByRateCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
