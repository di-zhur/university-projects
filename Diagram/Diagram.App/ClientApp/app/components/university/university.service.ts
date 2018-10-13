import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class UniversityService {
    static instance: UniversityService;
    private currentUniversity: University;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        return UniversityService.instance = UniversityService.instance || this;
    }

    public setCurrentUniversity(university: University) {
        this.currentUniversity = university;
    }

    public getCurrentUniversity(): University {
        return this.currentUniversity;
    }
}

@Injectable() 
export class University {
    id: string;
    shortName: string;
    name: string;
    description: string;
    imageId: string;
}