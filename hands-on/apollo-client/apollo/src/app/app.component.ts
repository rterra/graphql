import { Component } from '@angular/core';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';
import { Observable } from 'rxjs';
import { ApolloQueryResult, NetworkStatus } from 'apollo-client';


const QUERY = gql`
query loadPessoa($id) {
  pessoa(id:$id) {
    id
    name
    cv {
      texto
    }
  }
}
`;

const MUTATION = gql`
mutation updPessoa {
  updatePessoa {
    id
    name
  }
}`;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'apollo';
  NetworkStatus = NetworkStatus;

  public result$: Observable<ApolloQueryResult<any>>;
  public myid = "kkkk";
  constructor( private apollo: Apollo) {
    this.result$ = apollo.watchQuery( {
      query: QUERY,
      variables: { id: this.myid }
    }).valueChanges;

    this.result$.subscribe( s => console.log(s));
    



    //.subscribe( s => console.log(s));
  }


  mutate() {
    this.apollo.mutate({
      mutation: MUTATION
    }).subscribe( s => console.log(s));
  }

  refresh() {
    this.result$ = this.apollo.query( {
      query: QUERY
    });
  }
}
