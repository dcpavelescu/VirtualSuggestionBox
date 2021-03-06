import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { AddNewSuggestionComponent } from './addNewSuggestion/add-new-suggestion.component';
import { AppRoutingModule } from './/app-routing.module';
import { HomeComponent } from './home/home.component';
import { SuggestionDetailsComponent } from './suggestion-details/suggestion-details.component';
import { SuggestionsViewComponent } from './suggestions-view/suggestions-view.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CategoryComponent } from './category/category.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegistrationComponent } from './registration/registration.component';
import { HttpClientModule } from '@angular/common/http';
import { SuggestionService } from './_services/suggestion.service';
import { Top3Component } from './top3/top3.component';
import { SearchByRateCategoryComponent } from './search-by-rate-category/search-by-rate-category.component';
import { RecentSuggestionComponent } from './recentSuggestion/recent-suggestion.component';

const appRoutes: Routes = [
  { path: 'add-new-suggestion', component: AddNewSuggestionComponent },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'search-by-rate-category', component: SearchByRateCategoryComponent },
  { path: 'top3', component: Top3Component },
  { path: 'recent', component: RecentSuggestionComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    AddNewSuggestionComponent,
    HomeComponent,
    SuggestionDetailsComponent,
    SuggestionsViewComponent,
    LoginComponent,
    DashboardComponent,
    CategoryComponent,
    RegistrationComponent,
    Top3Component,
    SearchByRateCategoryComponent,
    RecentSuggestionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    )
  ],

  providers: [AppComponent,SuggestionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
