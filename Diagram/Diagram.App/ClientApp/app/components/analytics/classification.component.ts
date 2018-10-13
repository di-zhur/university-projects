import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { DataService } from "../service/data.service";

@Component({
    selector: 'analytics-classification',
    templateUrl: './classification.component.html',
    providers: [DataService]
})

export class ClassificationComponent implements OnInit  {
    private showDropdownFaculty: boolean = false;
    private valuesDiagram: number[];
    private categoriesDiagram: string[];
    private conditionClassification: boolean = false;
    private values: any[];
    private universitys: Array<{ id: string, shortName: string }>;
    private facultys: Array<{ id: string, name: string }>;
    private currentUniversityId: string;

    constructor(private dataService: DataService,
                private http: Http,
                @Inject('BASE_URL') private baseUrl: string) { }

    ngOnInit() {
        this.dataService.getUniversitysWithObservable()
            .subscribe(univers => this.universitys = univers);
    }

    selectedUniversity(e: any) {
        if (e.id == null) {
            this.conditionClassification = false;
            this.showDropdownFaculty = false;
        }
        else {
            this.currentUniversityId = e.id;
            this.dataService.getFacultysByUniverWithObservable(e.id)
                .subscribe(facultys => this.facultys = facultys as Array<{ id: string, name: string }>);
            this.showDropdownFaculty = true;
        }
    }

    selectedFaculty(e: any) {
        this.conditionClassification = true;
        this.http.get(this.baseUrl + 'api/Diagram/GetClassification/'
            + '?universityId=' + this.currentUniversityId
            + '&facultyId=' + e.id)
            .subscribe(result => {
                var data = result.json();
                this.valuesDiagram = data.ValuesDiagram;
                this.categoriesDiagram = data.CategoriesDiagram;
                this.values = data.Values;
            },
            error => console.error(error));
    }
}




