import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { DataService } from "../service/data.service";

@Component({
    selector: 'analytics-forecast',
    templateUrl: './forecast.component.html',
    providers: [DataService]
})
export class ForecastComponent implements OnInit {
    private forecastData: number[];
    private categoriesData: number[];
    private valueForecast: any;
    private conditionForecast: boolean = false;
    private dropdownUniversitys: Array<{ id: string, shortName: string }>;
    private dropdownFacultys: Array<{ id: string, name: string }>;
    private dropdownSpecialtys: Array<{ id: string, name: string }>;
    private showDropdownFaculty: boolean = false;
    private showDropdownSpecialty: boolean = false;
    private currentUniversityId: string;
    private currentFacultyId: string;

    constructor(
        private dataService: DataService,
        private http: Http,
        @Inject('BASE_URL') private baseUrl: string) { }

    ngOnInit() {
        this.dataService.getUniversitysWithObservable()
            .subscribe(univers => this.dropdownUniversitys = univers as Array<{ id: string, shortName: string }>);
    }

    onApply() {
        this.conditionForecast = true;
        this.http.get(this.baseUrl + 'api/Diagram/GetForecast').subscribe(result => {
            var data = result.json();
            this.valueForecast = data;
            this.forecastData = data.Marks;
            this.categoriesData = data.Years;
        }, error => console.error(error));
    }

    selectedUniversity(e: any) {
        if (e.id == null) {
            this.showDropdownFaculty = false;
        }
        else {
            this.currentUniversityId = e.id;
            this.dataService.getFacultysByUniverWithObservable(e.id)
                .subscribe(facultys => this.dropdownFacultys = facultys as Array<{ id: string, name: string }>);
            this.showDropdownFaculty = true;
        }
    }

    selectedFaculty(e: any) {
        if (e.id == null) {
            this.showDropdownSpecialty = false;
        }
        else {
            this.currentFacultyId = e.id;
            this.dataService.getSpecialtyByFacultyWithObservable(e.id)
                .subscribe(spec => this.dropdownSpecialtys = spec as Array<{ id: string, name: string }>);
            this.showDropdownSpecialty = true;
        }
    }

    selectedSpecialty(e: any) {
        if (e.id != null) {
            this.conditionForecast = true;
            this.http.get(this.baseUrl + 'api/Diagram/GetForecast/' +
                '?universityId=' + this.currentUniversityId +
                '&facultyId=' + this.currentFacultyId +
                '&specialtyId=' + e.id)
                .subscribe(result => {
                var data = result.json();
                this.valueForecast = data;
                this.forecastData = data.Marks;
                this.categoriesData = data.Years;
            }, error => console.error(error));
        }
    }

}


