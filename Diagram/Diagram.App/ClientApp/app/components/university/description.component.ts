import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { University, UniversityService } from './university.service';

@Component({
    selector: 'university-description',
    templateUrl: './description.component.html',
    providers: [UniversityService]
})
    
export class DescriptionComponent implements OnInit {
    private currentUniversity: University;
    private facultyDescriptions: any;

    constructor(private service: UniversityService, private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }

    ngOnInit() {
        this.currentUniversity = this.service.getCurrentUniversity();
        this.http.get(this.baseUrl + 'api/Diagram/GetFacultyDescription/?universityId=' + this.currentUniversity.id).subscribe(result => {
            this.facultyDescriptions = result.json();
        }, error => console.error(error));
    }
}

