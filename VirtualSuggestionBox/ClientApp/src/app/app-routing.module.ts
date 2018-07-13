import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNewSuggestionComponent } from './addNewSuggestion/add-new-suggestion.component';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';

const routes: Routes = [
  { path: 'add-new-suggestion', component: AddNewSuggestionComponent },
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

