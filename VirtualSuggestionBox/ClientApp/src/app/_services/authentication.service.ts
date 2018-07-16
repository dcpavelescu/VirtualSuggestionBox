import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//nu se poate instala rxjs
//import { Observable } from 'rxjs/Observable';
//import 'rxjs/add/operator/map'
 
@Injectable()
export class AuthenticationService {
    constructor(private http: HttpClient) { }
 
    login(username: string, password: string) {
      return this.http.post<any>('/api/authenticate', { username: username, password: password });
          /*
           .map(user => {
                if (user && user.token) {
                    // local storage
                    localStorage.setItem('currentUser', JSON.stringify(user));
                }
 
                return user;
            });
            */
    }
 
    logout() {
        // delete local storage
        localStorage.removeItem('currentUser');
    }
}
