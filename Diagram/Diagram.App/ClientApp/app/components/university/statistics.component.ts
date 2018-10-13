import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { University, UniversityService } from './university.service';

@Component({
    selector: 'university-statistics',
    templateUrl: './statistics.component.html',
    providers: [UniversityService]
})

export class StatisticsComponent implements OnInit {
    private setTotals: SetTotal[];
    private conditionFaculty: boolean = false;
    private conditionSetTotal: boolean = false;
    private dropdownFacultys: Array<{ id: string, name: string }>
    private dropdownSpecialtys: Array<{ id: string, name: string }>

    constructor(private service: UniversityService, private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/Diagram/GetFacultyByUniversity/?universityId=' + this.service.getCurrentUniversity().id).subscribe(result => {
            this.dropdownFacultys = result.json() as Array<{ id: string, name: string }>;
        }, error => console.error(error));
    }

    selectedSpecialty(facultyId: string): void {
        if (facultyId == null) {
            this.conditionFaculty = false;
            this.conditionSetTotal = false;
        }
        else {
            this.http.get(this.baseUrl + 'api/Diagram/GetSpecialtyByFaculty/?facultyId=' + facultyId).subscribe(result => {
                this.dropdownSpecialtys = result.json() as Array<{ id: string, name: string }>;
            }, error => console.error(error));
            this.conditionFaculty = true;
        }
    }

    selectedFaculty(specialtyId : string): void {
        if (specialtyId  == null) {
            this.conditionSetTotal = false;
        }
        else {
            this.http.get(this.baseUrl + 'api/Diagram/GetSetTotalBy/?specialtyId=' + specialtyId).subscribe(result => {
                this.setTotals = result.json() as SetTotal[];
            }, error => console.error(error));
            this.conditionSetTotal = true;
        }
    }
}


interface SetTotal {
    year: number;
    places: number;
    request: number;
    budgetPlaces: number;
    payPlaces: number;
    mark: number;
    contest: number;
}



