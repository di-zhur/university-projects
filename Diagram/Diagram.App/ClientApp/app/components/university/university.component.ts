import { Component, Inject} from '@angular/core';
import { Http } from '@angular/http';
import { University, UniversityService } from './university.service';

@Component({
    selector: 'university',
    templateUrl: './university.component.html',
    providers: [UniversityService]
})


export class UniversityComponent {
    public university: University;

    constructor(private service: UniversityService, private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        this.university = service.getCurrentUniversity();
    }
}
