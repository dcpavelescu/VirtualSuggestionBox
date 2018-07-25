import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNewSuggestionComponent } from './addNewSuggestion/add-new-suggestion.component';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { HomeComponent } from './home/home.component';
import { Top3Component } from './top3/top3.component';
import { SearchByRateCategoryComponent } from './search-by-rate-category/search-by-rate-category.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'new', component: AddNewSuggestionComponent },
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'search-by-rate-category', component: SearchByRateCategoryComponent },
  { path: 'top3', component: Top3Component }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

