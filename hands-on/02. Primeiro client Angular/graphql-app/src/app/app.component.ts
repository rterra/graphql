import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public graphQLhttp$: Observable<any>;

  title = 'graphql-app';
  token = '1c3b005ef91520d116f335ec42a7eda55436af1e';
  github_endpoint = 'https://api.github.com/graphql';

  constructor(private http: HttpClient) {
  }

  getCurrentRepoDescription() {
    let headers = new HttpHeaders()
        .set('Content-Type','application/json')
        .set('Authorization', 'token ' + this.token);

    // const cmd = '{\n "query": "{viewer { login, createdAt }}" \n}';
    const cmd = '{\n "query": "{ repository(owner:\\"rterra\\", name:\\"graphql\\") { description }}" \n}';

    this.graphQLhttp$ = this.http
        .post(this.github_endpoint, cmd, { headers: headers })
        .pipe( tap(s => console.log(s) ));

  }
}
