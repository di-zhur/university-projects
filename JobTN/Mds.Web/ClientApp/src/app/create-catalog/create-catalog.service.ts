import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
import 'rxjs/Rx';
import { map } from 'rxjs/operators';


@Injectable()
export class CreateCatalogService {
  private webApiUrl: string;

  constructor(private http: HttpClient) {
    this.webApiUrl = 'https://localhost:44309/';
  }

  getRegisteredParticipants(): Observable<Array<any>> {
    return this.http
      .get(this.webApiUrl + 'RegisteredParticipant/Get')
      .map(this.extractData)
      .catch(this.handleErrorObservable);
  }

  public postCreateTable(table: any) {
    var body = JSON.stringify(table);
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.post(this.webApiUrl + 'api/data', table, { headers: headers })
      .map(res => res)
      .catch((error: any) => {
        return Observable.throw(error);
      });
  }

  private extractData(res: Response) {
    let body = res.json();
    return body;
  }

  private handleErrorObservable(error: Response | any) {
    console.error(error.message || error);
    return Observable.throw(error.message || error);
  }

}

export class Table {
  name: string = undefined;
  fields: Field[] = [];
}

export class Field {
  name: string;
  dataType: string;
}
