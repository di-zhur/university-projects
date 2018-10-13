import { Injectable, Inject } from '@angular/core';
import { Response, Http } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';


@Injectable()
export class DataService {

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    getCitysWithObservable(): Observable<Array<{ id: string, name: string }>> {
        return this.http.get(this.baseUrl + 'api/Diagram/GetCity')
            .map(this.extractData)
            .catch(this.handleErrorObservable);
    }

    getSpecializationsWithObservable(): Observable<Array<{ id: string, name: string }>> {
        return this.http.get(this.baseUrl + 'api/Diagram/GetSpecialization')
            .map(this.extractData)
            .catch(this.handleErrorObservable);
    }
      
    getUniversitysWithObservable(): Observable<any> {
        return this.http.get(this.baseUrl + 'api/Diagram/GetUniversity')
            .map(this.extractData)
            .catch(this.handleErrorObservable);
    }
    
    getFacultysWithObservable(): Observable<any> {
        return this.http.get(this.baseUrl + 'api/Diagram/GetFaculty')
            .map(this.extractData)
            .catch(this.handleErrorObservable);
    }

    getFacultysByUniverWithObservable(universityId: string): Observable<any> {
        return this.http.get(this.baseUrl + 'api/Diagram/GetFacultyByUniversity/?universityId=' + universityId)
            .map(this.extractData)
            .catch(this.handleErrorObservable);
    }

    getSpecialtyByFacultyWithObservable(facultyId: string): Observable<any> {
        return this.http.get(this.baseUrl + 'api/Diagram/GetSpecialtyByFaculty/?facultyId=' + facultyId)
            .map(this.extractData)
            .catch(this.handleErrorObservable);
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