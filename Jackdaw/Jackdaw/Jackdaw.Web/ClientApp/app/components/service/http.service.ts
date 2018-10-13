import { Injectable, Inject } from '@angular/core';
import { Response, Http } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';


@Injectable()
export class RegistrationService {
    private webApiUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        this.webApiUrl = 'http://localhost:53313/api/';
    }

    getInstitutions(): Observable<Array<{ id: string, name: string }>> {
        return this.http
            .get(this.webApiUrl + 'institution/get')
            .map(this.extractData)
            .catch(this.handleErrorObservable);
    }

    getRegisteredContest(): Observable<Array<any>> {
        return this.http
            .get(this.webApiUrl + 'RegisteredContest/Get')
            .map(this.extractData)
            .catch(this.handleErrorObservable);
    }

    getRegisteredParticipants(): Observable<Array<any>> {
        return this.http
            .get(this.webApiUrl + 'RegisteredParticipant/Get')
            .map(this.extractData)
            .catch(this.handleErrorObservable);
    }

    getRegisteredСalculatedParticipants(): Observable<Array<any>> {
        return this.http
            .get(this.webApiUrl + 'RegisteredParticipant/GetСalculated')
            .map(this.extractData)
            .catch(this.handleErrorObservable);
    }
    
    getRegisteredParticipant(id: number): Observable<Array<any>> {
        return this.http
            .get(this.webApiUrl + 'RegisteredParticipant/GetById/' + id)
            .map(this.extractData)
            .catch(this.handleErrorObservable);
    }

    postRegisteredParticipant(registeredParticipant: RegisteredParticipant) {
        var body = JSON.stringify(registeredParticipant);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        return this.http.post(this.webApiUrl + 'RegisteredParticipant/Post', body, { headers: headers })
            .map(res => res.json())
            .catch((error: any) => { return Observable.throw(error); });;
    }

    postCalculationMarks(registeredContestId: number) {
        var body = JSON.stringify(registeredContestId);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        return this.http.post(this.webApiUrl + 'RegisteredParticipant/CalculationMarks', body, { headers: headers })
            .map(res => res.json())
            .catch((error: any) => { return Observable.throw(error); });;
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

@Injectable()
export class RegisteredParticipant {
    fio: string;
    email: string;
    nameWork: string;
    institutionId: number;
    registeredContestId: number;
    comment: string;
}