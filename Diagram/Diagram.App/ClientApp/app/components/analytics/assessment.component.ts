import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { DataService } from "../service/data.service";

@Component({
    selector: 'analytics-assessment',
    templateUrl: './assessment.component.html',
    providers: [DataService]
})

export class AssessmentComponent {
    private assessmentData: any[];
    private dropdownCitys: Array<{ id: string, name: string }> = [];
    private dropdownSpecializations: Array<{ id: string, name: string }> = [];
    private dropdownUniversitys: Array<{ id: string, shortName: string }> = [];
    private value: Array<{ id: string, name: string }> = [{ id: '0', name: 'Все' }];

    constructor(
        private dataService: DataService,
        private http: Http,
        @Inject('BASE_URL') private baseUrl: string) { }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/Diagram/GetAssessment').subscribe(result => {
                this.assessmentData = result.json();
        }, error => console.error(error));

        this.dataService.getCitysWithObservable()
            .subscribe(citys => this.dropdownCitys = citys);
        
        this.dataService.getSpecializationsWithObservable()
            .subscribe(spec => this.dropdownSpecializations = spec);
       
        this.dataService.getUniversitysWithObservable()
            .subscribe(universitys => this.dropdownUniversitys = universitys as Array<{ id: string, shortName: string }>);
    }
}


